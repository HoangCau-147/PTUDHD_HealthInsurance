import React, { useEffect, useState } from 'react';
import './styles.css';
import Select from 'react-select';
import { benefitsApi } from '../../services/Admin/ApiBenefit/benefit';
import { addInsurancesApi } from '../../services/Admin/ApiInsurance/insurance';
import { toast } from 'react-toastify';
import './ImageUpload.css';
import { AiFillFileImage } from 'react-icons/ai';
import { MdCloudUpload, MdDelete } from 'react-icons/md';
import { useNavigate } from 'react-router-dom';


const conditions = [
    {
        name: 'Bị tâm thần, bệnh phong, bệnh/hội chứng down, tự kỷ.',
        quesion: '',
    },
    {
        name: 'Thương tật vĩnh viễn từ 50% trở lên',
        quesion: '',
    },
    {
        name: 'Bị ung thư và/ hoặc đang trong quá trình điều trị bệnh/thương tật',
        quesion: '',
    },
    {
        name: ' Trong vòng 3 năm qua, Người được bảo hiểm đã từng được chẩn đoán, xuất hiện triệu chứng phải đi khám, điều trị hay đã được chuyên gia y tế khuyên Người được bảo hiểm phải điều trị hay không?',
        quesion: '',
    },
];
const AddInsurance = () => {
    const [selectedBenefitType, setSelectedBenefitType] = useState(null);
    const [image, setImage] = useState(null);
    const [imageUpload, setImageUpload] = useState(null);
    const [fileName, setFileName] = useState('No selected file');
    const [, setUrl] = useState('');
    const [loading, setLoading] = useState(false);
    const [benefitPrices, setBenefitPrices] = useState({});
    const [benefit, setBenefit] = useState([]);
    const [benefitType, setBenefitType] = useState([]);
    const navigate = useNavigate();
    const role = localStorage.getItem('role');

    useEffect(() => {
        const fetchData = async () => {
            if (role!=='Employee')
            {
            navigate('/');
            }
            try {
                const response = await benefitsApi();
                setBenefitType(response);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, []);

    //UploadImage
    const handleFileChange = ({ target: { files } }) => {
        if (files[0]) {
            const file = files[0];

            // Basic validation: Check if the file is an image
            if (file.type.startsWith('image/')) {
                setFileName(file.name);
                setImage(URL.createObjectURL(file));
                setImageUpload(file);
            } else {
                // Handle the case where the selected file is not an image
                alert('Please select a valid image file.');
            }
        }
    };

    const uploadImage = async () => {
        setLoading(true);
        const data = new FormData();
        data.append('file', imageUpload);
        data.append('upload_preset', process.env.REACT_APP_CLOUDINARY_UPLOAD_PRESET);
        data.append('cloud_name', process.env.REACT_APP_CLOUDINARY_CLOUD_NAME);
        data.append('folder', 'Cloudinary-React');

        try {
            const response = await fetch(
                `https://api.cloudinary.com/v1_1/${process.env.REACT_APP_CLOUDINARY_CLOUD_NAME}/image/upload`,
                {
                    method: 'POST',
                    body: data,
                },
            );
            const res = await response.json();
            setLoading(false);
            return res;
        } catch (error) {
            setLoading(false);
        }
    };
    //
    const options = conditions.map((condition) => ({
        value: condition.name,
        label: condition.name,
    }));

    const [selectedOption, setSelectedOption] = useState(null);

    const [formValues, setFormValues] = useState({
        name: '',
        insuredParty: '',
        territorialScope: '',
        participationProcedure: '',
        feeGuarantee: '',
        commitment: '',
        shortDescription: '',
        Bronze_price: '',
        Silver_price: '',
        Gold_price: '',
        Pla_price: '',
        Diamond_price: '',
    });

    const handleProgramChange = async (benefitTypeId) => {
        setSelectedBenefitType(benefitTypeId);
        try {
            let benefitTypebyID;
            for (let i = 0; i < benefitType.length; i++) {
                if (benefitType[i].benefitTypeId === benefitTypeId) {
                    benefitTypebyID = benefitType[i];
                }
            }
            setBenefit(benefitTypebyID);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const handleBenefitPriceChange = (benefitId, value) => {
        setBenefitPrices((prevPrices) => ({
            ...prevPrices,
            [benefitId]: value,
        }));
    };

    const handleSelectChange = (selectedOption) => {
        setSelectedOption(selectedOption);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormValues({
            ...formValues,
            [name]: value,
        });
    };
    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            // Upload image to Cloudinary
            const cloudinaryResponse = await uploadImage();
            const requiredFields = [
                'name',
                'insuredParty',
                'territorialScope',
                'participationProcedure',
                'feeGuarantee',
                'commitment',
                'shortDescription',
                'Bronze_price',
                'Silver_price',
                'Gold_price',
                'Pla_price',
                'Diamond_price',
            ];

            const hasEmptyField = requiredFields.some((field) => !formValues[field]);
            if (hasEmptyField) {
                // Display an error message or handle the case where not all required fields are filled
                toast.error('Please fill out all required fields.');
            }
            // Check if image upload was successful
            else if (cloudinaryResponse.secure_url && loading === false) {
                // Set the URL in the state
                setUrl(cloudinaryResponse.secure_url);
                let conditions_input;

                const programPrices_input = [
                    {
                        programName: 'Đồng',
                        price: formValues.Bronze_price,
                    },
                    {
                        programName: 'Bạc',
                        price: formValues.Silver_price,
                    },
                    {
                        programName: 'Vàng',
                        price: formValues.Gold_price,
                    },
                    {
                        programName: 'Bạch Kim',
                        price: formValues.Pla_price,
                    },
                    {
                        programName: 'Kim Cương',
                        price: formValues.Diamond_price,
                    },
                ];

                let benefitTypes = [
                    {
                        benefitTypeId: selectedBenefitType,
                        name: benefit.name,
                        benefits: [],
                    },
                ];
                let benefits = [];

                Object.entries(benefitPrices).forEach(([key, value]) => {
                    benefits.push({
                        benefitId: key,
                        price: value,
                    });
                });
                benefitTypes[0].benefits = benefits;

                if (selectedOption === null || benefits.length === 0) {
                    toast.error('Please fill out all required fields.');
                } else {
                    let check = true;
                    conditions_input = selectedOption.map((condition) => ({
                        name: condition.value,
                        question: '',
                    }));
                    if (conditions_input.length === 0) {
                        check = false;
                    }
                    for (let i = 0; i < benefits.length; i++) {
                        if (benefits[i].price === '' || benefits[i].price === 0) {
                            check = false;
                        }
                    }
                    // Call the API to add insurances
                    if (check === true) {
                        await addInsurancesApi(
                            formValues.name,
                            formValues.insuredParty,
                            formValues.territorialScope,
                            formValues.participationProcedure,
                            formValues.feeGuarantee,
                            formValues.commitment,
                            formValues.shortDescription,
                            cloudinaryResponse.secure_url,
                            conditions_input,
                            programPrices_input,
                            benefitTypes,
                        );
                        toast.success('Add Insurances Successfully!!');
                    } else {
                        toast.error('Please fill out all required fields.');
                    }
                }
            } else {
                toast.error('Image upload failed. Please try again.');
            }
        } catch (error) {
            console.error('Error:', error);
            toast.error('An error occurred. Please try again.');
        }
    };

    return (
        <div style={{ paddingLeft: '260px' }}>
            <div style={{ height: '100px', width: '100%', textAlign: 'center', marginTop: '50px' }}>
                <span style={{ fontSize: '25px', color: 'green', paddingTop: '50px', fontWeight: 'bold' }}>
                    Thêm Bảo Hiểm
                </span>
            </div>
            <form
                className="details"
                style={{ display: 'flex', justifyContent: 'center', fontSize: '14px' }}
                onSubmit={handleSubmit}
            >
                <div className="box-left" style={{ marginRight: '100px' }}>
                    <div className="image-container">
                        <main>
                            <form
                                className="image-field"
                                onClick={() => document.querySelector('.input-field').click()}
                            >
                                <input
                                    type="file"
                                    accept="image/*"
                                    className="input-field"
                                    hidden
                                    onChange={handleFileChange}
                                />
                                {image ? (
                                    <img src={image} width={400} height={250} alt={fileName} />
                                ) : (
                                    <>
                                        <MdCloudUpload color="#1475cf" size={60} />
                                        <p>Browse Files to upload</p>
                                    </>
                                )}
                            </form>
                            <section className="uploaded-row">
                                <AiFillFileImage color="#1475cf" />
                                <span className="upload-content">
                                    {fileName.length > 20 ? fileName.slice(0, 20) + '...' : fileName}
                                    {'  -  '}
                                    <MdDelete
                                        onClick={() => {
                                            setFileName('No selected File');
                                            setImage(null);
                                        }}
                                    ></MdDelete>
                                </span>
                            </section>
                        </main>
                    </div>
                    <div>
                        <span>Benefit</span>
                        <br></br>
                        <select
                            style={{ width: '500px', height: '30px', borderColor: 'lightgray' }}
                            onChange={(e) => handleProgramChange(parseInt(e.target.value))}
                        >
                            <option style={{ width: '500px', height: '30px' }} value="" disabled selected hidden>
                                Chọn loại Benefit
                            </option>
                            {benefitType?.length > 0 &&
                                benefitType?.map((benefit) => (
                                    <option
                                        style={{ width: '500px', height: '30px' }}
                                        key={benefit.benefitTypeId}
                                        value={benefit.benefitTypeId}
                                    >
                                        {benefit.name}
                                    </option>
                                ))}
                        </select>

                        <br></br>
                        <br></br>
                        <div>
                            <label>Thêm giá tiền cho lợi ích: </label>
                            {benefit.benefits?.length > 0 &&
                                benefit.benefits.map((benefits) => (
                                    <div key={benefits.benefitId}>
                                        <input
                                            type="number"
                                            id={`benefitPrice_${benefits.benefitId}`}
                                            name={`benefitPrice_${benefits.benefitId}`}
                                            onChange={(e) =>
                                                handleBenefitPriceChange(benefits.benefitId, e.target.value)
                                            }
                                            style={{ height: '30px' }}
                                            placeholder={
                                                benefits.benefitName.length > 67
                                                    ? `${benefits.benefitName.substring(0, 67)}...`
                                                    : benefits.benefitName
                                            }
                                        />
                                        <br></br>
                                        <br></br>
                                    </div>
                                ))}
                        </div>
                        <br></br>
                        <div
                            className="row"
                            style={{ width: '510px' /* Adjust the width as needed */, marginBottom: '10px' }}
                        >
                            <Select
                                isMulti
                                value={selectedOption}
                                onChange={handleSelectChange}
                                options={options}
                                placeholder="Chọn điều kiện"
                                styles={{
                                    container: (provided) => ({
                                        ...provided,
                                        width: '100%', // Ensure the container takes the full width
                                    }),
                                }}
                            />
                        </div>
                    </div>
                </div>

                <div className="box" style={{ marginLeft: '100px' }}>
                    <div onSubmit={handleSubmit}>
                        <div className="row">
                            <input
                                type="text"
                                id="productName"
                                name="name"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Tên Bảo Hiểm"
                            />
                        </div>
                        <div className="row">
                            <input
                                type="text"
                                id="insuredParty"
                                name="insuredParty"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Đối tượng được sử dụng bảo hiểm"
                            />
                        </div>
                        <div className="row">
                            <input
                                type="text"
                                id="territorialScope"
                                name="territorialScope"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Phạm vi"
                            />
                        </div>
                        <div className="row">
                            <input
                                type="text"
                                id="participationProcedure"
                                name="participationProcedure"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Thủ tục tham gia"
                            />
                        </div>
                        <div className="row">
                            <input
                                type="text"
                                id="feeGuarantee"
                                name="feeGuarantee"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Phí đảm bảo"
                            />
                        </div>
                        <div className="row">
                            <input
                                type="text"
                                id="commitment"
                                name="commitment"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Sự cam kết"
                            />
                        </div>

                        <div className="row">
                            <textarea
                                id="shortDescription"
                                name="shortDescription"
                                style={{ height: '70px' }}
                                onChange={handleChange}
                                placeholder="Mô tả"
                            />
                        </div>

                        <div className="row">
                            <label htmlFor="productPrice">Thêm giá tiền chương trình: </label>
                            <input
                                type="number"
                                id="productPrice"
                                name="Bronze_price"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Đồng"
                            />
                            <br></br>
                            <br></br>
                            <input
                                type="number"
                                id="productPrice"
                                name="Silver_price"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Bạc"
                            />
                            <br></br>
                            <br></br>
                            <input
                                type="number"
                                id="productPrice"
                                name="Gold_price"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Vàng"
                            />
                            <br></br>
                            <br></br>
                            <input
                                type="number"
                                id="productPrice"
                                name="Pla_price"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Bạch Kim"
                            />
                            <br></br>
                            <br></br>
                            <input
                                type="number"
                                id="productPrice"
                                name="Diamond_price"
                                style={{ height: '30px' }}
                                onChange={handleChange}
                                placeholder="Kim Cương"
                            />
                        </div>
                    </div>
                </div>
                <div>
                    <button type="submit" className="add" style={{ backgroundColor: '#16a317' }}>
                        <span style={{ fontWeight: 'bold', color: 'white', fontSize: '15px' }}>Thêm Bảo Hiểm</span>
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddInsurance;
