import React, { useEffect, useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import classNames from 'classnames/bind';

import styles from './Register.module.scss';
import Banner from '../../assets/image/banner-top.jpg';

//icon
import { RiHealthBookFill } from 'react-icons/ri';
import { GiHealthNormal } from 'react-icons/gi';

import { RegisterProductApi, RegisterCustomerApi, RegisterContractApi } from '../../services/ApiRegister/Register';
import { toast } from 'react-toastify';

const cx = classNames.bind(styles);

const role = localStorage.getItem('role');

function Register() {
    const { id } = useParams();
    let negative = useNavigate();
    const [activeSection, setActiveSection] = useState('information_insurance');
    const [productData, setProductData] = useState({});
    const [selectedProgram, setSelectedProgram] = useState(1);
    const [startDay, setStartDay] = useState('');
    const [toDay, setToDay] = useState('');
    const [totalFee, setTotalFee] = useState(0);
    const [answers, setAnswers] = useState([]);

    let listDisease = [
        {
            listOne: 'Bệnh hệ thần kinh',
            Disease: [
                {
                    number: 1,
                    name: 'Viêm hệ thần kinh trung ương (Não)',
                    status: false,
                },
                {
                    number: 2,
                    name: 'Parkinson, Alzheimer',
                    status: false,
                },
                {
                    number: 3,
                    name: 'Thoái hóa khác của hệ thần kinh',
                    status: false,
                },
                {
                    number: 4,
                    name: 'Mất trí nhớ, hôn mê, bại não, liệt',
                    status: false,
                },
                {
                    number: 5,
                    name: 'Bỏng dưới độ III',
                    status: false,
                },
                {
                    number: 6,
                    name: 'Hội chứng Apallic',
                    status: false,
                },
                {
                    number: 7,
                    name: '	Phẫu thuật não',
                    status: false,
                },
                {
                    number: 8,
                    name: 'Viêm màng não, viêm não do virus',
                    status: false,
                },
                {
                    number: 9,
                    name: 'Xơ cứng rải rác (đa xơ cứng)',
                    status: false,
                },
                {
                    number: 10,
                    name: 'Loạn dưỡng cơ',
                    status: false,
                },
                {
                    number: 11,
                    name: 'Nhược cơ',
                    status: false,
                },
                {
                    number: 12,
                    name: 'Bỏng nặng từ độ III trở lên',
                    status: false,
                },
            ],
        },
        {
            listOne: 'Bệnh hệ hô hấp',
            Disease: [
                {
                    number: 13,
                    name: 'Suy phổi, tràn khí phổi, suy hô hấp mãn tính',
                    status: false,
                },
                {
                    number: 14,
                    name: 'Phẫu thuật cất bỏ 1 bên phổi',
                    status: false,
                },
                {
                    number: 15,
                    name: 'Tăng áp động mạch phối',
                    status: false,
                },
                {
                    number: 16,
                    name: 'Bệnh phổi giai đoạn cuối',
                    status: false,
                },
            ],
        },
        {
            listOne: 'Bệnh hệ tuần hoàn',
            Disease: [
                {
                    number: 16,
                    name: 'Tim',
                    status: false,
                },
                {
                    number: 17,
                    name: 'Tăng áp lực động mạch vành vô căn',
                    status: false,
                },
                {
                    number: 18,
                    name: 'Mạch máu não/đột quy (xuất huyết não, xơ cứng động mạch)',
                    status: false,
                },
                {
                    number: 19,
                    name: 'Nhồi máu cơ tim, suy tìm mắt bù, bệnh tim giai đoạn cuối',
                    status: false,
                },
                {
                    number: 20,
                    name: 'Phẫu thuật động mạch chủ/van tim, ghép tim',
                    status: false,
                },
                {
                    number: 21,
                    name: 'Phẫu thuật nối tắt động mạch vành',
                    status: false,
                },
            ],
        },
        {
            listOne: 'Bệnh hệ tiêu hóa',
            Disease: [
                {
                    number: 22,
                    name: 'Viêm gan A',
                    status: false,
                },
                {
                    number: 23,
                    name: 'Viêm gan B',
                    status: false,
                },
                {
                    number: 24,
                    name: 'Viêm gan C',
                    status: false,
                },
                {
                    number: 25,
                    name: 'Viêm gan siêu vi tối cấp',
                    status: false,
                },
                {
                    number: 26,
                    name: 'Xơ gan',
                    status: false,
                },
                {
                    number: 27,
                    name: 'Bệnh Crohn',
                    status: false,
                },
                {
                    number: 28,
                    name: 'Phẫu thuật gan',
                    status: false,
                },
                {
                    number: 29,
                    name: 'Suy gan (bệnh gan giai đoạn cuối)',
                    status: false,
                },
            ],
        },
        {
            listOne: 'Bệnh hệ tiết niệu',
            Disease: [
                {
                    number: 30,
                    name: 'Suy thận, teo thận, sỏi thận cả 2 bên',
                    status: false,
                },
                {
                    number: 31,
                    name: 'Chạy thận nhân tạo',
                    status: false,
                },
            ],
        },
        {
            listOne: 'Bệnh hệ nội tiết, dinh dưỡng, chuyển hóa',
            Disease: [
                {
                    number: 32,
                    name: 'Rối loạn tuyến giáp',
                    status: false,
                },
                {
                    number: 33,
                    name: 'Cường giáp',
                    status: false,
                },
                {
                    number: 34,
                    name: 'Suy giáp',
                    status: false,
                },
                {
                    number: 35,
                    name: 'Basedow (Bướu cổ)',
                    status: false,
                },
                {
                    number: 36,
                    name: 'Tiểu đường chỉ số trên 11 mmol/l Tiểu đường đã gây biến chứng',
                    status: false,
                },
                {
                    number: 37,
                    name: 'Tiểu đường chỉ số từ 8 - 10 mmol/l',
                    status: false,
                },
            ],
        },
    ];
    const [diseaseList, setDiseaseList] = useState(listDisease);

    //
    const handelProductDescription = () => {
        setActiveSection('information_insurance');
    };
    const handelHeathInfor = () => {
        setActiveSection('information_heath');
    };

    useEffect(() => {
        fetchData();
    }, []);
    useEffect(() => {
        calculateTotalFee(selectedProgram);
    }, [productData]);

    const fetchData = async () => {
        try {

            const response = await RegisterProductApi(id);
            setProductData(response);
            const initialAnswers = response.conditions.map((condition) => ({
                id: condition.healthConditionId,
                status: false,
            }));
            setAnswers(initialAnswers);

        } catch (error) {
            console.error('>>> Error fetching data: ', error);
        }
    };

    const handleProgramChange = (programId) => {
        // Cập nhật state khi chọn một chương trình mới
        setSelectedProgram(programId);
        calculateTotalFee(programId);
    };

    const calculateTotalFee = (programId) => {
        const selectedProgramPrice =
            productData && productData.benefitType
                ? productData.programPrice.find((price) => price.programId === programId)
                : 0;

        if (selectedProgramPrice) {
            // Lấy giá trị từ programPrice của chương trình được chọn
            const totalProgramFee = selectedProgramPrice.price;

            // Cập nhật state cho tổng phí
            setTotalFee(totalProgramFee);
        } else {
            setTotalFee(0);
        }
    };

    const handleDateChange = (event, setDate) => {
        const selectedDate = event.target.value;
        setDate(selectedDate);

        // Nếu bạn muốn toDay là 1 năm sau startDay
        if (setDate === setStartDay) {
            const oneYearLater = new Date(selectedDate);
            oneYearLater.setFullYear(oneYearLater.getFullYear() + 1);
            setToDay(oneYearLater.toISOString().split('T')[0]);
        }
    };
    const handlePayment = async () => {
        try {
            if (!startDay || !toDay) {
                toast.error('Vui lòng chọn cả hai ngày');
            } else {
                const user = localStorage.getItem('token');
                // Phân tách token thành ba phần: Header, Payload, Signature
                let parts = user.split('.');

                // Giải mã Payload
                let decodedPayload = JSON.parse(atob(parts[1]));

                // Lấy giá trị của thuộc tính "emailaddress"
                let emailAddress = decodedPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
                const customer = await RegisterCustomerApi(emailAddress);
                const selectedDiseases = getDiseasesWithTrueStatus();
                let selectedDiseasesString = '';
                selectedDiseasesString = selectedDiseases.join('? ');
                await RegisterContractApi(
                    id,
                    selectedProgram,
                    startDay,
                    toDay,
                    totalFee,
                    selectedDiseasesString,
                    0,
                    customer,
                    answers,
                );
                toast.success('Đăng kí thành công');
                negative('/');
            }
        } catch (error) {
            toast.error('Đăng kí thất bại');
        }
    };

    const handleCheckboxChange = (healthConditionId, answer) => {
        setAnswers((prevAnswers) =>
            prevAnswers.map((ans) => (ans.id === healthConditionId ? { ...ans, status: answer } : ans)),
        );
    };

    const handleDiseaseCheckboxChange = (listOne, diseaseNumber) => {
        // Tìm bệnh lý trong state diseaseList
        const updatedList = diseaseList.map((category) => {
            if (category.listOne === listOne) {
                return {
                    ...category,
                    Disease: category.Disease.map((disease) => {
                        if (disease.number === diseaseNumber) {
                            return {
                                ...disease,
                                status: !disease.status, // Đảo ngược trạng thái
                            };
                        }
                        return disease;
                    }),
                };
            }
            return category;
        });

        // Cập nhật state diseaseList
        setDiseaseList(updatedList);
    };

    const renderDiseaseRows = () => {
        return diseaseList.map((category, index) => (
            <React.Fragment key={index}>
                <tr>
                    <td colSpan="3" style={{ fontWeight: 'bold' }}>
                        {category.listOne}
                    </td>
                </tr>
                {category.Disease.map((disease, subIndex) => (
                    <tr key={subIndex}>
                        <td>{disease.number}</td>
                        <td>
                            <span>{disease.name}</span>
                        </td>
                        <td>
                            <input
                                type="checkbox"
                                className="css_checkbox"
                                checked={disease.status} // Kết nối trạng thái checkbox với trạng thái của bệnh
                                onChange={() => handleDiseaseCheckboxChange(category.listOne, disease.number)}
                            />
                        </td>
                    </tr>
                ))}
            </React.Fragment>
        ));
    };

    const getDiseasesWithTrueStatus = () => {
        const diseasesWithTrueStatus = [];

        // Lặp qua danh sách bệnh và kiểm tra trạng thái
        diseaseList.forEach((category) => {
            category.Disease.forEach((disease) => {
                if (disease.status) {
                    diseasesWithTrueStatus.push(disease.name);
                }
            });
        });

        return diseasesWithTrueStatus;
    };

    return (
        <>
            <div className={cx('header')}>
                <img style={{ borderRadius: '0px' }} className={cx('banner_top')} src={Banner} alt="Banner" />
                <h1 className={cx('title')}>Sức khỏe</h1>
            </div>
            <div className={cx('content_container')}>
                <div className={cx('left_container')}>
                    <nav className={cx('navigation')}>
                        <li onClick={handelProductDescription}>
                            <Link to="">Thông tin bảo hiểm</Link>
                        </li>
                        <li onClick={handelHeathInfor}>
                            <Link to="">Tình trạng sức khỏe</Link>
                        </li>
                    </nav>

                    <div className={cx('content')}>
                        {/* thông tin bảo hiểm */}
                        <section
                            id={cx('information_insurance')}
                            className={cx({ active: activeSection === 'information_insurance' })}
                        >
                            <div className={cx('scope')}>
                                <div className={cx('title_form', 'under_title')}>
                                    <GiHealthNormal />
                                    <h2>Phạm vi bảo hiểm</h2>
                                </div>
                                <div className={cx('insurance_duration')}>
                                    <div className={cx('date')}>
                                        <span>
                                            Thời hạn BH từ <span style={{ color: 'red' }}> *</span>
                                        </span>
                                        <input
                                            value={startDay}
                                            onChange={(event) => handleDateChange(event, setStartDay)}
                                            type="date"
                                        />
                                    </div>
                                    <div className={cx('date')}>
                                        <span>Đến</span>
                                        <input value={toDay} readOnly type="date" />
                                    </div>
                                </div>
                                <div className={cx('insurance_policy')}>
                                    <span>
                                        Chương trình <span style={{ color: 'red' }}> *</span>
                                    </span>
                                    <select onChange={(e) => handleProgramChange(parseInt(e.target.value))}>
                                        {productData.benefitType &&
                                            productData.benefitType[0].benefits[0].benefitProgramCosts.map(
                                                (program) => (
                                                    <option key={program.programId} value={program.programId}>
                                                        {program.programName}
                                                    </option>
                                                ),
                                            )}
                                    </select>
                                </div>
                                <div className={cx('main_terms')}>
                                    {productData &&
                                        productData.benefitType &&
                                        Object.values(productData.benefitType).map((benefitType) => (
                                            <div style={{ width: '100%' }} key={benefitType.benefitTypeId}>
                                                {benefitType.benefits.map((benefitDetail) => (
                                                    <div className={cx('benefit')} key={benefitDetail.benefitId}>
                                                        <div className={cx('benefit-label')}>
                                                            <input checked style={{ opacity: '0.5' }} type="checkbox" />
                                                            <span>{benefitDetail.benefitName}</span>
                                                        </div>
                                                        {benefitDetail.benefitProgramCosts
                                                            .filter(
                                                                (programCost) =>
                                                                    programCost.programId === selectedProgram,
                                                            )
                                                            .map((filteredProgramCost) => (
                                                                <input
                                                                    key={filteredProgramCost.programId}
                                                                    type="text"
                                                                    value={`${filteredProgramCost.price}VNĐ`}
                                                                    readOnly
                                                                    className={cx('fee_benefit-label')}
                                                                />
                                                            ))}
                                                    </div>
                                                ))}
                                            </div>
                                        ))}
                                </div>

                                <div className={cx('fee')}>
                                    <span>Phí</span>
                                    <input type="text" value={`${totalFee} VND`} readOnly />
                                </div>
                            </div>

                            <div className={cx('health_status')}>
                                <div className={cx('title_form', 'under_title')}>
                                    <RiHealthBookFill />
                                    <h2>Thông tin tình trạng sức khỏe</h2>
                                </div>
                                {productData && productData.conditions && productData.conditions.length > 0 ? (
                                    productData.conditions.map((condition, index) => (
                                        <div style={{ margin: '2rem 2.4rem' }} key={index}>
                                            <strong>
                                                <u>Câu {index + 1}: </u>
                                            </strong>
                                            {condition.name}
                                            <br />

                                            <div className="form-inline">
                                                <div>
                                                    <input
                                                        style={{ width: '20px', height: '20px', marginRight: '1rem' }}
                                                        type="checkbox"
                                                        className=" form-check-input"
                                                        checked={
                                                            answers && answers.length > 0
                                                                ? answers.find(
                                                                    (ans) => ans.id === condition.healthConditionId,
                                                                )?.status === true
                                                                    ? true
                                                                    : false
                                                                : false
                                                        }
                                                        onChange={() =>
                                                            handleCheckboxChange(condition.healthConditionId, true)
                                                        }
                                                    />
                                                    <span className="form-check-label" style={{ paddingRight: '50%' }}>
                                                        Có
                                                    </span>
                                                </div>

                                                <div>
                                                    <input
                                                        type="checkbox"
                                                        className=" form-check-input"
                                                        style={{ width: '20px', height: '20px', marginRight: '1rem' }}
                                                        checked={
                                                            answers && answers.length > 0
                                                                ? answers.find(
                                                                    (ans) => ans.id === condition.healthConditionId,
                                                                )?.status === false
                                                                    ? true
                                                                    : false
                                                                : true
                                                        }
                                                        onChange={() =>
                                                            handleCheckboxChange(condition.healthConditionId, false)
                                                        }
                                                    />
                                                    <span className="form-check-label">Không</span>
                                                </div>
                                            </div>
                                        </div>
                                    ))
                                ) : (
                                    <p>không có dữ liệu</p>
                                )}
                                <button
                                    style={{
                                        borderRadius: '0px',
                                        backgroundColor: '#066132',
                                        width: '40%',
                                        alignSelf: 'center',
                                    }}
                                    onClick={handelHeathInfor}
                                >
                                    Khai báo tình trạng sức khỏe
                                </button>
                            </div>
                        </section>

                        {/* tình trạng sức khỏe */}
                        <section
                            id={cx('information_heath')}
                            className={cx({ active: activeSection === 'information_heath' })}
                        >
                            <div
                                className="tab-pane item-tab fade show block-post active"
                                id={cx('UPa_ks')}
                                role="tabpanel"
                                aria-labelledby="sk-tab"
                            // onmouseup="bhhd_ngskKM_KTRA()"
                            >
                                <div className={cx('title-form')}>
                                    <span>THÔNG TIN VỀ TÌNH TRẠNG SỨC KHỎE</span>
                                </div>
                                <table cellspacing="0" cellpadding="0" className={cx('table-ctr')}>
                                    <tbody>
                                        <tr>
                                            <th width="50px">STT</th>
                                            <th width="70%">Bạn có mắc phải những bệnh dưới đây không?</th>
                                            <th>Có</th>
                                        </tr>
                                        {renderDiseaseRows()}
                                    </tbody>
                                </table>
                            </div>
                        </section>
                    </div>
                </div>

                <div className={cx('bill')}>
                    <h1>Thông tin phí bảo hiểm</h1>
                    <hr />
                    <div className={cx('row')}>
                        <div>
                            <label style={{ color: 'rgba(134, 120, 120, 1)' }} id={cx('lblphi')}>
                                Phí:
                            </label>
                        </div>
                        <div className={cx('col')}>
                            <span id={cx('phi_tien_phi')}>{totalFee}</span>
                            <span id={cx('vndphi')} className={cx('price')}>
                                {' '}
                                VND
                            </span>
                        </div>
                    </div>
                    <hr />
                    <div className={cx('row')}>
                        <div>
                            <label id={cx('lblphi')}>Tổng phí:</label>
                        </div>
                        <div className={cx('col')}>
                            <span id={cx('phi_tien_phi')}>{totalFee}</span>
                            <span id={cx('vndphi')} className={cx('price')}>
                                {' '}
                                VND
                            </span>
                        </div>
                    </div>
                    <hr />
                    <button className={cx('pay-btn')} onClick={() => handlePayment()}>
                        Đăng kí
                    </button>
                </div>
            </div>
        </>
    );
}
export default Register;
