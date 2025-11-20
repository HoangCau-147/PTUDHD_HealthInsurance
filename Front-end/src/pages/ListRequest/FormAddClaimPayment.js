import './FormAddClaimPayment.css';
import { addClaimPayment } from './../../services/Admin/ApiRequest/request';
import React, { useEffect, useState } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const FormAddClaimPayment = (props) => {
    const [requestId, setRequestId] = useState('');
    const [serviceName, setServiceName] = useState('');
    const [costOfATreatment, setCostOfATreatment] = useState(0);
    const [hospitalName, setHospitalName] = useState('');
    const [usedDate, setUsedDate] = useState('');
    const [claimHeaths, setClaimHeaths] = useState([]);

    const [isOpen, setIsOpen] = useState(true);
    useEffect(() => {
        setIsOpen(true);
    }, []);
    const closeImage = () => {
        setIsOpen(false);
        props.hidden(true);
    };

    const addPayment = () => {
        if (serviceName && costOfATreatment >= 0 && hospitalName && usedDate) {
            const newClaimHealth = {
                serviceName,
                costOfATreatment,
                hospitalName,
                usedDate,
            };

            setClaimHeaths([...claimHeaths, newClaimHealth]);

            setServiceName('');
            setCostOfATreatment(0);
            setHospitalName('');
            setUsedDate('');
        } else {
            alert('Vui lòng nhập đầy đủ thông tin');
        }
    };

    const PostData = async (data) => {
        const response = await addClaimPayment(data);
        if (response.status == 201) {
            toast.success('Xác nhận yêu cầu thành công');
            closeImage();
        } else {
            toast.error('');
        }
    };

    const handleSumit = () => {
        console.log(claimHeaths);
        if (claimHeaths && props.claim.claimRequestId) {
            const data = {
                requestId: props.claim.claimRequestId,
                claimHeaths: claimHeaths,
            };
            console.log(data);
            PostData(data);
        } else {
            toast.error('Chưa có thông tin thanh toán');
        }
    };

    if (isOpen) {
        return (
            <div className={`form ${isOpen ? 'open' : 'closed'}`}>
                <div className={`container ${isOpen ? 'open' : 'closed'}`}>
                    <div id="payment-id">
                        <h1>Mã Yêu Cầu: {props.claim.claimRequestId}</h1>
                        <h1>Bảo hiểm: {props.claim.productName}</h1>
                        <h1>Chương trình: {props.claim.programName}</h1>
                    </div>
                    <div className="content-container">
                        <div className="form-container">
                            <h2>Form thêm mục thanh toán</h2>
                            <label htmlFor="service-name">
                                Dịch vụ:
                                <input
                                    type="text"
                                    id="service-name"
                                    value={serviceName}
                                    onChange={(e) => setServiceName(e.target.value)}
                                />
                            </label>

                            <label htmlFor="cost">
                                Chi phí:
                                <input
                                    type="number"
                                    id="cost"
                                    value={costOfATreatment}
                                    onChange={(e) => setCostOfATreatment(e.target.value)}
                                />
                            </label>

                            <label htmlFor="hospital">
                                Bệnh viện:
                                <input
                                    type="text"
                                    id="hospital"
                                    value={hospitalName}
                                    onChange={(e) => setHospitalName(e.target.value)}
                                />
                            </label>

                            <label htmlFor="used-date">
                                Ngày sử dụng:
                                <input
                                    type="date"
                                    id="used-date"
                                    value={usedDate}
                                    onChange={(e) => setUsedDate(e.target.value)}
                                />
                            </label>

                            <button id="add-payment" onClick={addPayment}>
                                Thêm thanh toán
                            </button>
                        </div>

                        <div className="payment-list">
                            <h2>Danh sách thanh toán</h2>
                            <table className="payment-table">
                                <thead>
                                    <tr>
                                        <th>Dịch vụ</th>
                                        <th>Chi phí</th>
                                        <th>Bệnh viện</th>
                                        <th>Ngày sử dụng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {claimHeaths.map((claim, index) => (
                                        <tr key={index}>
                                            <td>{claim.serviceName}</td>
                                            <td>${claim.costOfATreatment}</td>
                                            <td>{claim.hospitalName}</td>
                                            <td>{claim.usedDate}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div className="container-btn">
                        <button
                            style={{ width: '200px', backgroundColor: 'rgba(255, 0, 0, 0.7)' }}
                            onClick={() => closeImage()}
                        >
                            Đóng
                        </button>
                        <button style={{ width: '200px' }} onClick={() => handleSumit()}>
                            Xác nhận
                        </button>
                    </div>
                </div>
            </div>
        );
    }
};

export { FormAddClaimPayment };
