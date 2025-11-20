import 'bootstrap/dist/css/bootstrap.min.css';
import React, { useState } from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import companyLogo from '../../../../assets/image/Logo2.png';
import './css/custom.css';
import Banner from '../../../../assets/image/banner-top.jpg';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Sidebar = ({ children }) => {
    const navigate = useNavigate();
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [activeLink, setActiveLink] = useState('/admin');
    const [activeDropdown, setActiveDropdown] = useState('/admin/layouts');
    const [activeDropdown1, setActiveDropdown1] = useState('/admin/payment');
    const [isDropdownOpen1, setIsDropdownOpen1] = useState(false);
    const handleLogout = () => {
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        navigate('/login');
        toast.success('Logout Success!');
    };
    const handleMouseEnter = () => {
        setIsDropdownOpen(true);
    };
    const handleMouseEnter1 = () => {
        setIsDropdownOpen1(true);
    };
    const handleMouseLeave = () => {
        setIsDropdownOpen(false);
    };
    const handleMouseLeave1 = () => {
        setIsDropdownOpen1(false);
    };
    const handleNavLinkClick = (path) => {
        setActiveLink(path);
        // Perform any other actions if needed
    };
    const handleDropdownClick = (path) => {
        setActiveDropdown(path);
        setActiveDropdown1(path);
    };

    const handleDropdownToggleClick = (event) => {
        event.preventDefault(); // Prevent the default behavior (e.g., navigation)
    };
    const handleDropdownToggleClick1 = (event) => {
        event.preventDefault(); // Prevent the default behavior (e.g., navigation)
    };

    return (
        <div>
            <div id="sidebar">
                <div class="sidebar-header">
                    <h3>
                        <img style={{ borderRadius: '0px' }} src={companyLogo} class="img-fluid" />
                        <span>Nhóm 8</span>
                    </h3>
                </div>
                <ul class="list-unstyled component m-0">
                    <li className={activeLink === '/admin' ? 'active' : ''}>
                        <NavLink
                            to="/admin/"
                            className="link"
                            activeclassName="active"
                            onClick={() => {
                                handleDropdownClick('');
                                handleNavLinkClick('/admin');
                            }}
                        >
                            <i class="material-icons">home</i>Trang chủ{' '}
                        </NavLink>
                    </li>
                    <li className={activeLink === '/admin/registers/' ? 'active' : ''}>
                        <NavLink
                            to="/admin/registers/"
                            className="link"
                            activeclassName="active"
                            onClick={() => {
                                handleDropdownClick('');
                                handleNavLinkClick('/admin/registers/');
                            }}
                        >
                            <i class="material-icons">apps</i> Phiếu Đăng ký{' '}
                        </NavLink>
                    </li>
                    <li className={activeLink === '/admin/users/' ? 'active' : ''}>
                        <NavLink
                            to="/admin/users/"
                            className="link"
                            activeclassName="active"
                            onClick={() => {
                                handleDropdownClick('');
                                handleNavLinkClick('/admin/users/');
                            }}
                        >
                            <i class="material-icons">person</i>Khách Hàng{' '}
                        </NavLink>
                    </li>
                    <li className={activeLink === '/admin/request/' ? 'active' : ''}>
                        <NavLink
                            to="/admin/request/"
                            className="link"
                            activeclassName="active"
                            onClick={() => {
                                handleDropdownClick('');
                                handleNavLinkClick('/admin/request/');
                            }}
                        >
                            <i class="material-icons">request_quote</i>Phiếu Yêu Cầu{' '}
                        </NavLink>
                    </li>
                    <li
                        className={`dropdown ${isDropdownOpen1 ? 'show' : ''} ${activeLink === '/admin/payment' ? 'active' : ''
                            }`}
                        onMouseEnter={handleMouseEnter1}
                        onMouseLeave={handleMouseLeave1}
                    >
                        <a
                            href=""
                            data-toggle="collapse"
                            aria-expanded="false"
                            className="dropdown-toggle"
                            onClick={(e) => handleDropdownToggleClick1(e)}
                        >
                            <i className="material-icons">aspect_ratio</i>Phiếu thanh toán
                        </a>

                        <ul
                            className={`collapse list-unstyled menu ${isDropdownOpen1 ? 'show' : ''}`}
                            id="homeSubmenu1"
                        >
                            <li className={activeDropdown1 === '/admin/payment' ? 'active' : ''} >
                                <NavLink
                                    to="/admin/payment"
                                    onClick={() => {
                                        handleDropdownClick('/admin/payment');
                                        handleNavLinkClick('/admin/payment');
                                    }}
                                >
                                    <p style={{ paddingLeft: '20px' }} >Chưa thanh toán</p>
                                </NavLink>
                            </li>
                            <li className={activeDropdown1 === '/admin/paymentpaid' ? 'active' : ''} >
                                <NavLink
                                    to="/admin/paymentpaid"
                                    onClick={() => {
                                        handleDropdownClick('/admin/paymentpaid');
                                        handleNavLinkClick('/admin/payment');
                                    }}
                                >
                                    <p style={{ paddingLeft: '20px' }}>Đã thanh toán</p>
                                </NavLink>
                            </li>
                        </ul>
                    </li>
                    <li
                        className={`dropdown ${isDropdownOpen ? 'show' : ''} ${activeLink === '/admin/layouts' ? 'active' : ''
                            }`}
                        onMouseEnter={handleMouseEnter}
                        onMouseLeave={handleMouseLeave}
                    >
                        <a
                            href=""
                            data-toggle="collapse"
                            aria-expanded="false"
                            className="dropdown-toggle"
                            onClick={(e) => handleDropdownToggleClick(e)}
                        >
                            <i className="material-icons">&#xe1d5;</i>Bảo hiểm
                        </a>

                        <ul className={`collapse list-unstyled menu ${isDropdownOpen ? 'show' : ''}`} id="homeSubmenu1">
                            <li className={activeDropdown === '/admin/insurances' ? 'active' : ''}  >
                                <NavLink
                                    to="/admin/insurances/"
                                    onClick={() => {
                                        handleDropdownClick('/admin/insurances');
                                        handleNavLinkClick('/admin/layouts');
                                    }}
                                >
                                    <p style={{ paddingLeft: '20px' }}>Insurance</p>
                                    
                                </NavLink>
                            </li>
                            <li className={activeDropdown === '/admin/benefits' ? 'active' : ''} >
                                <NavLink
                                    to="/admin/benefits/"
                                    onClick={() => {
                                        handleDropdownClick('/admin/benefits');
                                        handleNavLinkClick('/admin/layouts');
                                    }}
                                >
                                    <p style={{ paddingLeft: '20px' }}>Benefit</p>
                                    
                                </NavLink>
                            </li>
                        </ul>
                    </li>
                    <li class="" style={{ position: 'absolute', bottom: 0 , width:'100%'}}>
                        <a onClick={handleLogout}>
                            <i class="material-icons">exit_to_app</i>Đăng xuất{' '}
                        </a>
                    </li>
                </ul>
            </div>
            <main>{children}</main>
        </div>
    );
};

export default Sidebar;
