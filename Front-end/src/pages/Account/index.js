import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import classNames from 'classnames/bind';
import Chart from './Chart';
import PersonalInfomation from './PersonalInfo';
import styles from './Account.module.scss';
import './DetailsContract.scss';
import Banner from '../../assets/image/banner-top.jpg';
import CustomerRequest from './../CustomerRequest/CustomerRequest';

import { AccountCustomerApi, ContractsCustomerApi } from '../../services/ApiAccount/Account';
import DetailContract from './../DetailContract/index';

const cx = classNames.bind(styles);
const role = localStorage.getItem('role');

function Account() {
    const navigate = useNavigate();
    const [activeSection, setActiveSection] = useState('list_insurance');
    const [activeListInsurance, setActiveListInsurance] = useState('list_isWaiting');
    const [activeListRequire, setActiveListRequire] = useState(0);
    const [contractStatus, setContractStatus] = useState(0);
    const [contractsOfCustomer, setContractsOfCustomer] = useState([]);
    const [registerDetail, setRegisterDetail] = useState({});
    const [showForm, setShowForm] = useState(false);
    const [requestStatus, setRequestStatus] = useState(0);
    const [customer, setCustomer] = useState({});


    const handleClickListInsurance = () => {
        if (role === 'Customer') {
            // Xử lý sự kiện chỉ khi role là Customer
            handelListInsurance();
        }
    };

    const handleClickListRequire = () => {
        if (role === 'Customer') {
            // Xử lý sự kiện chỉ khi role là Customer
            handelListRequire();
        }
    };

    const handleClickRevenue = () => {
        if (role === 'Customer') {
            // Xử lý sự kiện chỉ khi role là Customer
            handelRevenue();
        }
    };

    //
    const handelListInsurance = (state) => {
        setActiveSection('list_insurance');
        const listInsuranceSection = document.getElementById(cx('list_insurance'));
        if (listInsuranceSection) {
            listInsuranceSection.style.display = 'flex';
        }
        const listRequireSection = document.getElementById(cx('list_require'));
        if (listRequireSection) {
            listRequireSection.style.display = 'none';
        }
        const revenue = document.getElementById(cx('revenue'));
        if (revenue) {
            revenue.style.display = 'none';
        }
        const profile = document.getElementById(cx('profile'));
        if (profile) {
            profile.style.display = 'none';
        }
    };

    const handelListRequire = (state) => {
        setActiveSection('list_require');
        const listInsuranceSection = document.getElementById(cx('list_insurance'));
        if (listInsuranceSection) {
            listInsuranceSection.style.display = 'none';
        }

        const listRequireSection = document.getElementById(cx('list_require'));
        if (listRequireSection) {
            listRequireSection.style.display = 'flex';
        }
        const revenue = document.getElementById(cx('revenue'));
        if (revenue) {
            revenue.style.display = 'none';
        }
        const profile = document.getElementById(cx('profile'));
        if (profile) {
            profile.style.display = 'none';
        }
    };

    const handelRevenue = () => {
        setActiveSection('revenue');
        const listInsuranceSection = document.getElementById(cx('list_insurance'));
        if (listInsuranceSection) {
            listInsuranceSection.style.display = 'none';
        }
        const listRequireSection = document.getElementById(cx('list_require'));
        if (listRequireSection) {
            listRequireSection.style.display = 'none';
        }
        const revenue = document.getElementById(cx('revenue'));
        if (revenue) {
            revenue.style.display = 'flex';
        }
        const profile = document.getElementById(cx('profile'));
        if (profile) {
            profile.style.display = 'none';
        }
    };

    const handelProfile = () => {
        setActiveSection('profile');
        const listInsuranceSection = document.getElementById(cx('list_insurance'));
        if (listInsuranceSection) {
            listInsuranceSection.style.display = 'none';
        }
        const listRequireSection = document.getElementById(cx('list_require'));
        if (listRequireSection) {
            listRequireSection.style.display = 'none';
        }
        const revenue = document.getElementById(cx('revenue'));
        if (revenue) {
            revenue.style.display = 'none';
        }
        const profile = document.getElementById(cx('profile'));
        if (profile) {
            profile.style.display = 'flex';
        }
    };

    // nav in lest list

    const handelIsUnpaid = () => {
        setActiveListInsurance('list_isUnpaid');
        setContractStatus(0);
        setActiveListRequire(0);
    };

    const handelIsWaiting = () => {
        setActiveListInsurance('list_isWaiting');
        setContractStatus(0);
    };

    const handelIsCancel = () => {
        setActiveListInsurance('list_isCanceled');
        setContractStatus(1);
    };

    const handelIsActive = () => {
        setActiveListInsurance('list_isActive');
        setContractStatus(2);
    };

    const handelIsExpired = () => {
        setActiveListInsurance('list_isExpired');
        setContractStatus(3);
    };

    // list require
    const handelIsPaid = () => {
        setActiveListRequire(1);
    };
    const handelIsPending = () => {
        setActiveListRequire(2);
    };
    const handelIsDenied = () => {
        setActiveListRequire(3);
    };
    useEffect(() => {
        fetchData();
    }, [activeListInsurance]);

    const fetchData = async () => {
        try {

            const user = localStorage.getItem('token');
            // Phân tách token thành ba phần: Header, Payload, Signature
            let parts = user.split('.');

            // Giải mã Payload
            let decodedPayload = JSON.parse(atob(parts[1]));

            // Lấy giá trị của thuộc tính "emailaddress"
            let emailAddress = decodedPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
            if (role === 'Customer') {
                const customer = await AccountCustomerApi(emailAddress);
                const contractsCustomer = await ContractsCustomerApi(customer.customerId, contractStatus);
                setContractsOfCustomer(contractsCustomer);
                setCustomer(customer);
            }
            else {
                handelProfile();
            }

        } catch (error) {
            console.error('>>> Error fetching data: ', error);
        }
    };
    const [listHealthDeclaration, setListHealthDeclaration] = useState([]);
    const handleView = (id) => {
        let HealthDeclaration = '';
        for (let i = 0; i < contractsOfCustomer.length; i++) {
            if (contractsOfCustomer[i].contractId === id) {
                setRegisterDetail(contractsOfCustomer[i]);
                console.log('>>check contract; ');
                HealthDeclaration = contractsOfCustomer[i].healthDeclaration;
                break;
            }
        }
        if (HealthDeclaration) {
            const healthDeclarationArray = HealthDeclaration.split('?');
            setListHealthDeclaration(healthDeclarationArray);
        } else {
            setListHealthDeclaration([]);
        }
        setShowForm(!showForm);
    };

    return (
        <>
            <div className={cx('header')}>
                <img style={{ borderRadius: '0' }} className={cx('banner_top')} src={Banner} alt="Banner" />
                <h1 className={cx('title')}>Tài khoản</h1>
            </div>

            <nav className={cx('navigation')}>
                <li
                    onClick={handleClickListInsurance}
                    className={cx(activeSection === 'list_insurance' ? 'active_navbar' : '')}
                >
                    <Link to="">Thông tin bảo hiểm</Link>
                </li>
                <li
                    onClick={handleClickListRequire}
                    className={cx(activeSection === 'list_require' ? 'active_navbar' : '')}
                >
                    <Link to="">Thông tin phiếu yêu cầu</Link>
                </li>
                <li onClick={handleClickRevenue} className={cx(activeSection === 'revenue' ? 'active_navbar' : '')}>
                    <Link to="">Chi tiêu</Link>
                </li>
                <li onClick={handelProfile} className={cx(activeSection === 'profile' ? 'active_navbar' : '')}>
                    <Link to="">Thông tin cá nhân</Link>
                </li>
            </nav>

            <div className={cx('content')}>
                <section id={cx('list_insurance')} className={cx({ active: activeSection === 'list_insurance' })}>
                    <div className={cx('left_list')}>
                        <nav className={cx('navigation_leftList')}>
                            <li
                                id={cx('isWaiting')}
                                onClick={handelIsWaiting}
                                className={cx(activeListInsurance === 'list_isWaiting' ? 'active_leftlist' : '')}
                            >
                                <Link to="">Chờ duyệt</Link>
                            </li>
                            <li
                                onClick={handelIsCancel}
                                className={cx(activeListInsurance === 'list_isCanceled' ? 'active_leftlist' : '')}
                            >
                                <Link to="">Bị hủy</Link>
                            </li>
                            <li
                                onClick={handelIsActive}
                                className={cx(activeListInsurance === 'list_isActive' ? 'active_leftlist' : '')}
                            >
                                <Link to="">Đang thụ hưởng</Link>
                            </li>
                            <li
                                onClick={handelIsExpired}
                                className={cx(activeListInsurance === 'list_isExpired' ? 'active_leftlist' : '')}
                            >
                                <Link to="">Hết hạn</Link>
                            </li>
                        </nav>
                    </div>
                    <div className={cx('right_list')}>
                        <table className={cx('content-table')}>
                            <thead>
                                <tr>
                                    <th style={{ textAlign: 'center' }}>STT</th>
                                    <th style={{ textAlign: 'center' }}>Tên bảo hiểm</th>
                                    <th style={{ textAlign: 'center' }}>Chương trình</th>
                                    <th style={{ textAlign: 'center' }}>Ngày bắt đầu</th>
                                    <th style={{ textAlign: 'center' }}>Ngày kết thúc</th>
                                    <th style={{ textAlign: 'center' }}>Giá bảo hiểm</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {contractsOfCustomer && contractsOfCustomer.length > 0 ? (
                                    contractsOfCustomer.map((item, index) => (
                                        <tr key={index}>
                                            <td style={{ textAlign: 'center' }}>{index + 1}</td>
                                            <td>{item.productName}</td>
                                            <td>{item.programName}</td>
                                            <td style={{ textAlign: 'center' }}>
                                                {' '}
                                                {`${item.startDate.substring(0, 10)}`}
                                            </td>
                                            <td style={{ textAlign: 'center' }}>
                                                {' '}
                                                {`${item.endDate.substring(0, 10)}`}
                                            </td>
                                            <td style={{ textAlign: 'center' }}> {item.totalPrice}</td>
                                            <td>
                                                <button onClick={() => handleView(item.contractId)}>Chi tiết</button>
                                            </td>
                                        </tr>
                                    ))
                                ) : (
                                    <p>không có dữ liệu</p>
                                )}
                            </tbody>
                        </table>
                    </div>
                </section>

                <section
                    id={cx('list_require')}
                    className={cx({ active: activeSection === 'list_require' })}
                    style={{ display: 'none' }}
                >
                    <div className={cx('left_list')}>
                        <nav className={cx('navigation_leftList')}>
                            <li
                                onClick={() => handelIsUnpaid()}
                                className={cx(activeListRequire === 0 ? 'active_leftlist' : '')}
                            >
                                <Link to="">Chờ Duyệt</Link>
                            </li>
                            <li
                                onClick={() => handelIsPaid()}
                                className={cx(activeListRequire === 1 ? 'active_leftlist' : '')}
                            >
                                <Link to="">Chưa thanh toán</Link>
                            </li>
                            <li
                                onClick={() => handelIsPending()}
                                className={cx(activeListRequire === 2 ? 'active_leftlist' : '')}
                            >
                                <Link to="">Đã thanh toán</Link>
                            </li>
                            <li
                                onClick={handelIsDenied}
                                className={cx(activeListRequire === 3 ? 'active_leftlist' : '')}
                            >
                                <Link to="">Đã Hủy</Link>
                            </li>
                        </nav>
                    </div>
                    <div className={cx('right_list')}>
                        <CustomerRequest status={activeListRequire}></CustomerRequest>
                    </div>
                </section>
                <section id={cx('revenue')} className={cx({ active: activeSection === 'revenue' })}>
                    <Chart data={customer ? customer : ''}></Chart>
                </section>
                <section id={cx('profile')} className={cx({ active: activeSection === 'profile' })}>
                    <PersonalInfomation></PersonalInfomation>
                </section>
            </div>

            {showForm && (
                <div className="overlay-register">
                    <div className="form-container-register">
                        <div
                            style={{
                                height: '40px',
                                padding: '20px 0',
                                color: '#126131',
                                textTransform: 'uppercase',
                                fontWeight: '800',
                                fontSize: '1.8rem',
                            }}
                        >
                            Thông tin Đăng ký
                        </div>
                        <br></br>
                        <span
                            onClick={() => setShowForm(false)}
                            className="cancel"
                            title="cancel"
                            data-toggle="tooltip"
                        >
                            <i class="material-icons close">&#xe5cd;</i>
                        </span>
                        {registerDetail.customer ? (
                            <div className="table_register" style={{ textAlign: 'center' }}>
                                <table style={{ width: '80%' }}>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>Nhân viên duyệt</strong>
                                            </td>
                                            {/* <td>{registerDetail.employee}</td> */}
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Ngày bắt đầu</strong>
                                            </td>
                                            <td>{registerDetail.startDate}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Ngày kết thúc</strong>
                                            </td>
                                            <td>{registerDetail.endDate}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Giá bảo hiểm</strong>
                                            </td>
                                            <td>{registerDetail.totalPrice}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Trạng thái</strong>
                                            </td>
                                            <td>
                                                <span style={{ border: '0px' }}>
                                                    {registerDetail.status === 'Unpaid'
                                                        ? 'Chưa thanh toán'
                                                        : 'Đã thanh toán'}
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Tên khách hàng</strong>
                                            </td>
                                            <td>{registerDetail.customer.name}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>CMND/CCCD</strong>
                                            </td>
                                            <td>{registerDetail.customer.identifycationNumber}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Ngày sinh</strong>
                                            </td>
                                            <td>{registerDetail.customer.birthday}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Số điện thoại</strong>
                                            </td>
                                            <td>{registerDetail.customer.phoneNumber}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Email</strong>
                                            </td>
                                            <td>{registerDetail.customer.email}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Địa chỉ</strong>
                                            </td>
                                            <td>{registerDetail.customer.address}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Tên bảo hiểm</strong>
                                            </td>
                                            <td>{registerDetail.productName}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Ngày tạo</strong>
                                            </td>
                                            <td>{registerDetail.createDate}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Chương trình</strong>
                                            </td>
                                            <td>{registerDetail.programName}</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        ) : (
                            <p>Không có dữ liệu</p>
                        )}

                        <div className="table_healthinfo">
                            <div
                                style={{
                                    width: '100%',
                                    padding: '20px',
                                    color: '#126131',
                                    textTransform: 'uppercase',
                                    fontWeight: '800',
                                    fontSize: '1.8rem',
                                }}
                            >
                                Thông tin tình trạng sức khỏe của khách hàng
                            </div>

                            <table style={{ width: '80%' }}>
                                <thead>
                                    <tr>
                                        <th>STT</th>
                                        <th>Điều kiện sức khỏe</th>
                                        <th>Tình trạng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {registerDetail.contractHealthConditions.length > 0 ? (
                                        registerDetail.contractHealthConditions.map((curElem, i) => (
                                            <tr key={curElem.benefitTypeId}>
                                                <td>{i + 1}</td>
                                                <td>
                                                    <span>{curElem.conditionName}</span>
                                                </td>
                                                <td>
                                                    <span>{curElem.status ? 'Có' : 'Không'}</span>
                                                </td>
                                            </tr>
                                        ))
                                    ) : (
                                        <tr>
                                            <td colSpan="3">
                                                <span>Không có dữ liệu</span>
                                            </td>
                                        </tr>
                                    )}
                                </tbody>
                            </table>
                        </div>

                        <div className="table_healthinfo">
                            <div
                                style={{
                                    width: '100%',
                                    padding: '20px',
                                    color: '#126131',
                                    textTransform: 'uppercase',
                                    fontWeight: '800',
                                    fontSize: '1.8rem',
                                }}
                            >
                                Thông tin bệnh trạng của khách hàng
                            </div>

                            <table style={{ width: '80%' }}>
                                <thead>
                                    <tr>
                                        <th>STT</th>
                                        <th>Bệnh mắc phải</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {listHealthDeclaration && listHealthDeclaration.length > 0 ? (
                                        listHealthDeclaration.map((curElem, i) => (
                                            <tr key={curElem.benefitTypeId}>
                                                <td>{i + 1}</td>
                                                <td>
                                                    <span>{curElem}</span>
                                                </td>
                                            </tr>
                                        ))
                                    ) : (
                                        <tr>
                                            <td colSpan="3">
                                                <span>Không có dữ liệu</span>
                                            </td>
                                        </tr>
                                    )}
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            )}
        </>
    );
}

export default Account;
