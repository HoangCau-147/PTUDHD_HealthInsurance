import React, { useState, useEffect } from 'react';
import { Link, useParams, useNavigate } from 'react-router-dom';
import classNames from 'classnames/bind';
import styles from './Product.module.scss';
import Banner from '../../assets/image/banner-top.jpg';


import { ProductApi } from '../../services/ApiProduct/Product';

const cx = classNames.bind(styles);

const role = localStorage.getItem('role');

const Product = () => {
    const navigate = useNavigate();

    const { id } = useParams();
    const [activeSection, setActiveSection] = useState('product_des');
    const [activeProgram, setactiveProgram] = useState('');
    const [buttonTop, setButtonTop] = useState(100);

    const [productData, setProductData] = useState({});

    const [selectedProgram, setSelectedProgram] = useState(1);

    const handelProductDescription = () => {
        setActiveSection('product_des');
    };
    useEffect(() => {
        // Gọi fetchData khi component được render lần đầu tiên
        fetchData(id);
    }, []);

    const fetchData = async (productId) => {
        try {

            const response = await ProductApi(productId);
            console.log('>>>check response: ', response);
            if (response) {
                setProductData(response);
            } else {
                setProductData({});
            }

        } catch (error) {
            console.error('>>> Error fetching data: ', error);
        }
    };

    const conditions = productData && productData.conditions ? productData.conditions : [];
    //
    const handelBenifit = () => {
        setActiveSection('benifits');
    };
    const handelFee = () => {
        setActiveSection('fees');
    };

    //program
    const programHandleCopper = () => {
        setactiveProgram('copper');
        setSelectedProgram(1);
    };

    const programHandleSilver = () => {
        setactiveProgram('silver');
        setSelectedProgram(2);
    };

    const programHandleGold = () => {
        setactiveProgram('gold');
        setSelectedProgram(3);
    };

    const programHandlePlatinum = () => {
        setactiveProgram('platinum');
        setSelectedProgram(4);
    };

    const programHandleDiamond = () => {
        setactiveProgram('diamond');
        setSelectedProgram(5);
    };

    const getProgramPrice = (benefit, selectedProgram) => {
        const selectedProgramInfo = benefit.benefitProgramCosts.find(
            (program) => program.programId === selectedProgram,
        );
        return selectedProgramInfo ? selectedProgramInfo.price : 'N/A';
    };

    useEffect(() => {
        const handleScroll = () => {
            const content = document.querySelector('.content');
            if (content) {
                const contentRect = content.getBoundingClientRect();
                const newTop = contentRect.top > 0 ? contentRect.top : 0;
                setButtonTop(newTop);
            }
        };

        window.addEventListener('scroll', handleScroll);

        return () => {
            window.removeEventListener('scroll', handleScroll);
        };
    }, []); // Sử dụng [] để chỉ gọi useEffect một lần khi component được mount
    const handleRegister = () => {
        if (role === 'Customer') {
            navigate(`/register/${id}`);
        }
        else if (!role) {
            navigate('/login');
        }
        else {
            navigate('/admin');
        }
    }
    return (
        <>
            <div id={cx('dynamicButton')} className={cx('sticky-box', 'btn-base')} style={{ top: `${buttonTop}px` }}>
                <button onClick={() => handleRegister()}>Mua ngay</button>
            </div>
            <div className={cx('header')}>
                <img style={{ borderRadius: '0px' }} className={cx('banner_top')} src={Banner} alt="Banner" />
                <h1 className={cx('title')}>Sức khỏe</h1>
            </div>

            <nav className={cx('navigation')}>
                <li onClick={handelProductDescription}>
                    <Link to="">Mô tả sản phẩm</Link>
                </li>
                <li onClick={handelBenifit}>
                    <Link to=""> Quyền lợi bảo hiểm</Link>
                </li>
                <li onClick={handelFee}>
                    <Link to="">Phí bảo hiểm</Link>
                </li>
            </nav>

            <div className={cx('content')}>
                <h2>Bảo hiểm sức khỏe</h2>
                <section id={cx('product_des')} className={cx({ active: activeSection === 'product_des' })}>
                    <div className={cx('general_des')}>
                        <h5>
                            Vốn quý của con người là Sức Khỏe. Đảm bảo một sức khỏe tốt sẽ giúp chúng ta an tâm thực
                            hiện những ước mơ, hoài bão.
                        </h5>
                        <h5>{productData.shortDescription}</h5>
                    </div>

                    <div className={cx('beneficiary')}>
                        <h3 className={cx('under-title')}>
                            <span>Đối tượng được Bảo hiểm</span>
                        </h3>
                        <span>{productData.insuredParty}</span>
                    </div>

                    <div className={cx('country')}>
                        <h3 className={cx('under-title')}>
                            <span>PHẠM VI LÃNH THỔ:</span>
                        </h3>
                        <small>{productData.territorialScope}</small>
                    </div>

                    <div className={cx('additional_term')}>
                        <h3 className={cx('under-title')}>
                            <span>QUYỀN LỢI BẢO HIỂM BỔ SUNG:</span>
                        </h3>
                        <small>{productData.feeGuarantee}</small>
                    </div>
                    <div className={cx('parti_procedure')}>
                        <h3 className={cx('under-title')}>
                            <span>THỦ TỤC THAM GIA:</span>
                        </h3>
                        <small>{productData.participationProcedure}</small>
                    </div>

                    <div className={cx('fee_guarantee')}>
                        <h3 className={cx('under-title')}>
                            <span>BẢO LÃNH VIỆN PHÍ:</span>
                        </h3>
                        <small>Khách hàng được bảo lãnh viện phí với gần 200 cơ sở y tế trên toàn quốc.</small>
                    </div>

                    <div className={cx('commit')}>
                        <h3 className={cx('under-title')}>
                            <span>CAM KẾT:</span>
                        </h3>
                        <p>{productData.commitment}</p>
                    </div>
                </section>
                <section id={cx('benifits')} className={cx({ active: activeSection === 'benifits' })}>
                    <div className={cx('policy')}>
                        <h3 className={cx('under-title')}>
                            <span>QUYỀN LỢI BẢO HIỂM</span>
                            <small>(Click để xem chi tiết)</small>
                        </h3>
                        <nav className={cx('program')}>
                            <li onClick={programHandleCopper}>
                                <Link to="">Chương trình Đồng</Link>
                            </li>
                            <li onClick={programHandleSilver}>
                                <Link to="">Chương trình Bạc</Link>
                            </li>
                            <li onClick={programHandleGold}>
                                <Link to="">Chương trình Vàng</Link>
                            </li>
                            <li onClick={programHandlePlatinum}>
                                <Link to="">Chương trình Bạch Kim</Link>
                            </li>
                            <li onClick={programHandleDiamond}>
                                <Link to="">Chương trình Kim Cương</Link>
                            </li>
                        </nav>

                        <div className={cx('toggle-tab active', { active: activeProgram === 'product_des' })}>
                            <table cellspacing="0" cellpadding="0" className={cx('table-ctr')}>
                                <thead>
                                    <tr>
                                        <th>STT</th>
                                        <th>QUYỀN LỢI BẢO HIỂM</th>
                                        <th>
                                            <div className={cx('item-tab', { active: selectedProgram === 1 })}>
                                                CHƯƠNG TRÌNH ĐỒNG
                                            </div>
                                            <div className={cx('item-tab', { active: selectedProgram === 2 })}>
                                                CHƯƠNG TRÌNH BẠC
                                            </div>
                                            <div className={cx('item-tab', { active: selectedProgram === 3 })}>
                                                CHƯƠNG TRÌNH VÀNG
                                            </div>
                                            <div className={cx('item-tab', { active: selectedProgram === 4 })}>
                                                CHƯƠNG TRÌNH BẠCH KIM
                                            </div>
                                            <div className={cx('item-tab', { active: selectedProgram === 5 })}>
                                                CHƯƠNG TRÌNH KIM CƯƠNG
                                            </div>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td className={cx('align-left')}>
                                            <strong>Phạm vi lãnh thổ</strong>
                                        </td>
                                        <td>
                                            <strong>{productData.territorialScope}</strong>
                                        </td>
                                    </tr>

                                    {productData && productData.benefitType && productData.benefitType.length > 0 ? (
                                        productData.benefitType.map((benefitType, index) => (
                                            <React.Fragment key={benefitType.benefitTypeId}>
                                                <tr>
                                                    <td colSpan="3">
                                                        <b>{index + 1}</b>: {benefitType.name}
                                                    </td>
                                                </tr>

                                                {benefitType.benefits.map((benefit, index) => (
                                                    <tr key={benefit.benefitId}>
                                                        <td>{index + 1}</td>
                                                        <td className={cx('align-left')}>{benefit.benefitName}</td>
                                                        <td>
                                                            <div
                                                                className={cx('item-tab active')}
                                                                data-actab-group={benefitType.benefitTypeId}
                                                                data-actab-id={benefit.benefitId}
                                                            >
                                                                VND {getProgramPrice(benefit, selectedProgram)}
                                                            </div>
                                                        </td>
                                                    </tr>
                                                ))}
                                            </React.Fragment>
                                        ))
                                    ) : (
                                        // Không có dữ liệu productData, bạn có thể thực hiện một số thứ khác tại đây
                                        <p>Không có dữ liệu</p>
                                    )}
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div className={cx('wait_payment')}>
                        <h3 className={cx('under-title')}>
                            <span>Thời gian chờ và đồng chi trả</span>
                        </h3>
                        <div>
                            <span>Tai nạn:</span>
                            <span>0 ngày;</span>
                        </div>
                        <div>
                            <span>Bệnh thông thường:</span>
                            <span>30 ngày;</span>
                        </div>
                        <div>
                            <span>
                                Các bệnh hô hấp bao gồm viêm V.A cần phải nạo, viêm xoang, vẹo vách ngăn, viêm phế quản,
                                tiểu phế quản, viêm phổi, bệnh hen/suyễn (chỉ áp dụng cho trẻ em dưới 4 tuổi:
                            </span>
                            <span>90 (chín mươi) ngày</span>
                        </div>
                        <div>
                            <span>Biến chứng thai sản:</span>
                            <span>90 (chín mươi) ngày</span>
                        </div>
                        <h5>Lưu ý: Thời gian chờ không áp dụng cho các trường hợp tái tục liên tục.</h5>
                    </div>
                </section>
                <section id={cx('fees')} className={cx({ active: activeSection === 'fees' })}>
                    <h3 className={cx('under-title')}>
                        <span>PHÍ BẢO HIỂM</span>
                    </h3>
                    <span>
                        Là một chi phí định kỳ mà người tham gia bảo hiểm phải trả để duy trì quyền lợi và bảo vệ trong
                        kế hoạch bảo hiểm sức khỏe của các bạn
                    </span>
                </section>
            </div>
        </>
    );
};

export default Product;
