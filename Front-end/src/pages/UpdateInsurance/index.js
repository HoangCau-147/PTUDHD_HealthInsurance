import React, { useEffect,useState } from 'react';
import './styles.css';
import { useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';
import { getInsuranceByIdApi,updateInsurancesApi } from '../../services/Admin/ApiInsurance/insurance';
import { AiFillFileImage } from 'react-icons/ai';
import { MdCloudUpload, MdDelete } from 'react-icons/md';
import { toast } from 'react-toastify';


const UpdateInsurance = () => {
    // const [product, setProduct] = useState({
    //     name: 'Nike Shoes',
    //     price: 23,
    //     description: 'UI/UX designing, html css tutorials',
    // });

    const navigate = useNavigate();
    const [insurance, setInsurance] = useState({});
    const { id } = useParams();
    const role = localStorage.getItem('role');

    useEffect(() => {
        if (role!=='Employee')
        {
        navigate('/');
        }
        const fetchData = async () => {
            try {
                console.log('check>>', id);
                const response = await getInsuranceByIdApi(id);
                console.log('check>>', response);
                setInsurance(response);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, [id]);

    //upload image
    const url= insurance.imageUrl
    const [image, setImage] = useState(url|| '');
    useEffect(() => {
        // Kiểm tra nếu propValue là null hoặc undefined, không thực hiện cập nhật state
        if (url !== undefined && url !== null) {
          setImage(url);
        }
      }, [url]);
    const [imageUpload, setImageUpload] = useState(null);
    const [fileName, setFileName] = useState('No selected file');
    const [, setUrl] = useState('');
    const [loading, setLoading] = useState(false);

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

    //end update image
    
    // dung state de theo doi gia tri cac truong du lieu
    const [isButtonDisabled, setIsButtonDisabled] = useState(false);
    const [productName,setProductName]= useState(insurance.policyName||'');
    const [party,setParty]=useState(insurance.insuredParty||'');
    const [terrytory,setTerrytory]=useState(insurance.territorialScope||'');
    const [procedure,setProcedure]=useState(insurance.participationProcedure||'');
    const [guarantee,setGuarantee]=useState(insurance.feeGuarantee||'');
    const [commit, setCommit]=useState(insurance.commitment||'');
    const [descript,setDescript]=useState(insurance.shortDescription||'');
    const [img,setImg]=useState(insurance.imageUrl||'');
    useEffect(() => {
        // Thực hiện cập nhật state khi giá trị insurance thay đổi
        setProductName(insurance.policyName || '');
        setParty(insurance.insuredParty || '');
        setTerrytory(insurance.territorialScope || '');
        setProcedure(insurance.participationProcedure || '');
        setGuarantee(insurance.feeGuarantee || '');
        setCommit(insurance.commitment || '');
        setDescript(insurance.shortDescription || '');
        setImg(insurance.imageUrl || '');
      }, [insurance]);
    const handleChange = (e) => {
        // const { name, value } = e.target;
        // setFormValues({
        //     ...formValues,
        //     [name]: value,
        // });
    };
    const handleCancel=() =>{
        navigate(`/admin/insurances/`);
    }
    const handleSubmit = async(e) => {
        e.preventDefault();
        setIsButtonDisabled(true);
        // console.log('Submitted Product:', product);
        try{
            const cloudinaryResponse = await uploadImage();  
            if (cloudinaryResponse.secure_url && loading === false) {
                setImg(cloudinaryResponse.secure_url);
                await updateInsurancesApi(
                    insurance.productId,
                    productName,
                    party,
                    terrytory,
                    procedure,
                    guarantee,
                    commit,
                    descript,
                    cloudinaryResponse.secure_url,
                )
                
                toast.success('Điều chỉnh thông tin bảo hiểm thành công!');
                navigate(`/admin/insurances/`);
                
            }
            else{
                await updateInsurancesApi(
                    insurance.productId,
                    productName,
                    party,
                    terrytory,
                    procedure,
                    guarantee,
                    commit,
                    descript,
                    img,)
                    
                    toast.success('Điều chỉnh thông tin bảo hiểm thành công!');
                    navigate(`/admin/insurances/`);
            }
        }catch(error)
        {
            toast.error('Đã có lỗi xảy ra, vui lòng thực hiện lại')
            console.log("error:",error)
        }
        finally {
            // Kích hoạt lại nút sau khi xử lý hoàn tất
            setIsButtonDisabled(false);
            
        }
        
        // try{
        //     const cloudinaryResponse = await uploadImage();
            
        //     if (cloudinaryResponse.secure_url && loading === false) {
        //         // Set the URL in the state
        //         setUrl(cloudinaryResponse.secure_url);
        //         await updateInsurancesApi(
        //             insurance.productId,
        //             formValues.name,
        //             formValues.insuredParty,
        //             formValues.territorialScope,
        //             formValues.participationProcedure,
        //             formValues.feeGuarantee,
        //             formValues.commitment,
        //             formValues.shortDescription,
        //             cloudinaryResponse.secure_url,
        //         )

        //     }
        //     // Set the URL in the state
        // }catch (error) {
        //     console.error('Error:', error);
        //     toast.error('An error occurred. Please try again.');
        // }
    };
    return (
        <div style={{ paddingLeft: '260px' }}>
            <div style={{ height: '80px', width: '100%', textAlign: 'center', marginTop: '50px' }}>
                <span style={{ fontSize: '25px', color: '#006098', paddingTop: '50px', fontWeight: 'bold' }}>
                    Điều chỉnh thông tin bảo hiểm
                </span>
            </div>
            <div className="details">
                <div className="big-img" style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width:'120%' }}>
                    {/* <img className="img-item"src = {insurance.imageUrl} alt = "Product Image"/>  */}
                    <main> 
                        <form className="image-field" onClick={() => document.querySelector('.input-field').click()}>
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
                        <div >
                            <label htmlFor="productDescription">Mô tả:</label>
                            <textarea
                                id="productDescription"
                                name="shortDescription"
                                defaultValue={insurance.shortDescription}
                                onChange={(e)=>setDescript(e.target.value)}
                            />
                        </div>
                    </main>
                    
                </div>
                <div className="box">
                    <form onSubmit={handleSubmit}>
                        <div className="row">
                            <label htmlFor="productName">Tên Bảo Hiểm:</label>
                            <input
                                type="text"
                                id="productName"
                                name="name"
                                defaultValue={insurance.policyName}
                                onChange={(e)=>setProductName(e.target.value)}
                            />
                        </div>
                        <div className="row">
                            <label htmlFor="insuredParty">Bên tham gia bảo hiểm:</label>
                            <input
                                type="text"
                                id="insuredParty"
                                name="insuredParty"
                                defaultValue={insurance.insuredParty}
                                onChange={(e)=>setParty(e.target.value)}/>
                        </div>
                        <div className="row">
                            <label htmlFor="teritory">Lãnh thổ:</label>
                            <input  
                                type='text'
                                id="territory"
                                name="territorialScope"
                                defaultValue={insurance.territorialScope}
                                onChange={(e)=>setTerrytory(e.target.value)}
                            />
                        </div>
                        <div className="row">
                            <label htmlFor="teritory">Cam kết:</label>
                            <input  
                                type='text'
                                id="territory"
                                name="commitment"
                                defaultValue={insurance.commitment}
                                onChange={(e)=>setCommit(e.target.value)}
                            />
                        </div>
                        <div className="row">
                            <label htmlFor="guarantee">Bảo lãnh viện phí:</label>
                            <input  
                                type='text'
                                id="guarantee"
                                name="feeGuarantee"
                                defaultValue={insurance.feeGuarantee}
                                onChange={(e)=>setGuarantee(e.target.value)}
                            />
                        </div>
                        <div className="row">
                            <label htmlFor="procedure">Thủ tục:</label>
                            <input  
                                type='text'
                                id="procedure"
                                name="participationProcedure"
                                defaultValue={insurance.participationProcedure}
                                onChange={(e)=>setProcedure(e.target.value)}
                            />
                        </div>
                        {/* <div className="row">
                            <label htmlFor="productDescription">Mô tả:</label>
                            <textarea
                                id="productDescription"
                                name="shortDescription"
                                defaultValue={insurance.shortDescription}
                                onChange={(e)=>setDescript(e.target.value)}
                            />
                        </div> */}
                        
                    </form>
                </div>
                
            </div>
            <div className="rowforbtn">
                <button type="submit" class="cancel-btn" onClick={handleCancel} 
                disabled={isButtonDisabled} >
                        Hủy
                </button>
                <button type="submit" class="edit-btn" onClick={handleSubmit} 
                disabled={isButtonDisabled}>
                    
                        Lưu
                </button>
                
            </div>
        </div>
    );
};

export default UpdateInsurance;
