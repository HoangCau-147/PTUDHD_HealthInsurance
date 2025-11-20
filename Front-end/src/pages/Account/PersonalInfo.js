import React, { useState, useEffect } from 'react';
//
import classNames from 'classnames/bind';
import styles from './Account.module.scss';
import { AccountCustomerApi, UpdateCustomerApi, AccountEmployeeApi } from '../../services/ApiAccount/Account';
import { toast } from 'react-toastify';
const cx = classNames.bind(styles);

//

const PersonalInfomation = () => {
    const [isEditing, setIsEditing] = useState(true);
    const [userData, setUserData] = useState({});
    const [userName, setUserName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [birthdayUpdate, setBirthdayUpdate] = useState('');
    const [address, setAddress] = useState('');
    const [identifycationNumber, setIdentifycationNumber] = useState('');
    const [birthdayView, setBirthdayView] = useState('');



    const handleEditClick = () => {
        setIsEditing(false);
    };
    useEffect(() => {
        fetchData();
    }, [isEditing]);


    const fetchData = async () => {
        const user = localStorage.getItem('token');
        // Phân tách token thành ba phần: Header, Payload, Signature
        let parts = user.split('.');
        const role = localStorage.getItem('role')

        // Giải mã Payload
        let decodedPayload = JSON.parse(atob(parts[1]));

        // Lấy giá trị của thuộc tính "emailaddress"
        let emailAddress = decodedPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
        if (role === "Customer") {
            const customer = await AccountCustomerApi(emailAddress);
            setUserData(customer);
            setBirthdayView(customer.birthday.substring(0, 10));
            setUserInforDefault();
        }
        if (role === "Employee") {
            const employee = await AccountEmployeeApi(emailAddress);
            setUserData(employee);
            setBirthdayView(employee.birthday.substring(0, 10));
            setUserInforDefault();
        }

    }

    const validCustomerInfor = () => {
        if (userName && phoneNumber && birthdayUpdate && address && identifycationNumber) return true;
        else return false;
    }


    const setUserInforDefault = () => {
        setUserName(userData.name);
        setPhoneNumber(userData.phoneNumber);
        setBirthdayUpdate(birthdayView);
        setAddress(userData.address);
        setIdentifycationNumber(userData.identifycationNumber);
    }
    const handleSaveClick = async () => {
        const validCheck = validCustomerInfor();
        if (validCheck) {
            const customer = {
                "name": userName,
                "identifycationNumber": identifycationNumber,
                "birthday": birthdayUpdate,
                "phoneNumber": phoneNumber,
                "address": address
            }
            try {
                console.log(">>>check update customer: ", customer);
                await UpdateCustomerApi(userData.customerId, customer);
                setIsEditing(true);
                toast.success("cập nhật thông tin cá nhân thành công");
            } catch (error) {
                console.error("Lỗi khi cập nhật thông tin khách hàng:", error);
            }
        } else {
            toast.error("Hãy nhập đủ các trường!");
        }

    };

    return (
        <>
            {isEditing ? (
                <div style={{ width: '50%' }} class="card mb-3 mx-auto">
                    <div class="card-body text-center">
                        <div class="row mx-auto">
                            <div class="p-3 text-start col-sm-3">
                                <h3 class="mb-0">Họ và tên:</h3>
                            </div>
                            <div class="p-3 border text-start col-sm-8 text-secondary">{userData ? userData.name : ""}</div>
                        </div>

                        <div class="row mx-auto">
                            <div class="p-3 col-sm-3  text-start">
                                <h3 class="mb-0">ngày sinh:</h3>
                            </div>
                            <div class="col-sm-8 p-3 border text-start text-secondary">{userData ? birthdayView : ""}</div>
                        </div>
                        <div class="row mx-auto">
                            <div class="p-3 col-sm-3 text-start">
                                <h3 class="mb-0">CMND/CCCD:</h3>
                            </div>
                            <div class="col-sm-8 p-3 border text-start text-secondary">{userData ? userData.identifycationNumber : ""}</div>
                        </div>
                        <div class="row mx-auto">
                            <div class="col-sm-3 text-start p-3">
                                <h3 class="mb-0">Email:</h3>
                            </div>
                            <div class="col-sm-8 p-3 border text-start text-secondary">{userData ? userData.email : ""}</div>
                        </div>
                        <div class="row mx-auto">
                            <div class="col-sm-3 text-start p-3">
                                <h3 class="mb-0">Số diện thoại:</h3>
                            </div>
                            <div class="col-sm-8 p-3 border text-start text-secondary">{userData ? userData.phoneNumber : ""}</div>
                        </div>

                        <div class="row mx-auto">
                            <div class="col-sm-3 text-start p-3">
                                <h3 class="mb-0">Địa chỉ:</h3>
                            </div>
                            <div class="col-sm-8 p-3 border text-start text-secondary">{userData ? userData.address : ""}</div>
                        </div>

                        <div class="row p-3">
                            <div class="col-sm-12">
                                <a
                                    style={{ textTransform: 'uppercase' }}
                                    className="fs-5 btn btn-info "
                                    onClick={handleEditClick}
                                >
                                    Chỉnh sửa
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            ) : (
                <div style={{ width: '50%' }} class="card mb-3 mx-auto">
                    <div class="card-body">
                        <div class="row mt-4 mb-4">
                            <div class="col-sm-2 p-3">
                                <h3 class="mb-0">Họ và tên:</h3>
                            </div>
                            <div class="col-sm-9">
                                <div class=" input-group mb-3">
                                    <input
                                        type="text"
                                        name="Name"
                                        value={userName}
                                        onChange={(e) => setUserName(e.target.value)}
                                        class="p-3 fs-4 form-control"
                                        placeholder="Ví dụ:  Nguyen Văn A"
                                        aria-label="Sizing example input"
                                        aria-describedby="inputGroup-sizing-default"
                                    />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-4 mb-4">
                            <div class="col-sm-2 p-3">
                                <h3 class="mb-0">Ngày sinh:</h3>
                            </div>
                            <div class="col-sm-9">
                                <div class=" input-group mb-3">
                                    <input
                                        type="date"
                                        name="Birthday"
                                        value={birthdayUpdate}
                                        onChange={(e) => setBirthdayUpdate(e.target.value)}
                                        class="p-3 fs-4 form-control"
                                        aria-label="Sizing example input"
                                        aria-describedby="inputGroup-sizing-default"
                                    />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-4 mb-4">
                            <div class="col-sm-2 p-3">
                                <h3 class="mb-0">CMND?CCCD:</h3>
                            </div>
                            <div class="col-sm-9">
                                <div class=" input-group mb-3">
                                    <input
                                        type="text"
                                        name="ID"
                                        value={identifycationNumber}
                                        onChange={(e) => setIdentifycationNumber(e.target.value)}
                                        class="p-3 fs-4 form-control"
                                        placeholder="Ví dụ:  987654234"
                                        aria-label="Sizing example input"
                                        aria-describedby="inputGroup-sizing-default"
                                    />
                                </div>
                            </div>
                        </div>

                        <div class="row mt-4 mb-4">
                            <div class="col-sm-2 p-3">
                                <h3 class="mb-0">Số điện thoại:</h3>
                            </div>
                            <div class="col-sm-9">
                                <div class=" input-group mb-3">
                                    <input
                                        type="tel"
                                        name="phone"
                                        value={phoneNumber}
                                        onChange={(e) => setPhoneNumber(e.target.value)}
                                        class="p-3 fs-4 form-control"
                                        placeholder="Ví dụ: 0183338287"
                                        aria-label="Sizing example input"
                                        aria-describedby="inputGroup-sizing-default"
                                    />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-4 mb-4">
                            <div class="col-sm-2 p-3">
                                <h3 class="mb-0">Địa chỉ:</h3>
                            </div>
                            <div class="col-sm-9">
                                <div class=" input-group mb-3">
                                    <input
                                        type="text"
                                        name="address"
                                        value={address}
                                        onChange={(e) => setAddress(e.target.value)}
                                        class="p-3 fs-4 form-control"
                                        placeholder="Ví dụ: 123 Đinh Tiên Hoàng, Quận 3, TP Hồ Chí Minh"
                                        aria-label="Sizing example input"
                                        aria-describedby="inputGroup-sizing-default"
                                    />
                                </div>
                            </div>
                        </div>
                        {/* <label>Bio:</label>
                                            <textarea
                                                name="bio"
                                                value={userData.bio}
                                                onChange={handleInputChange}
                                            /> */}
                        <div class="row text-center">
                            <div class="col-sm-12">
                                <a
                                    style={{ textTransform: 'uppercase' }}
                                    className="fs-4 btn btn-info "
                                    onClick={handleSaveClick}
                                >
                                    Lưu
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </>
    );
};

export default PersonalInfomation;
