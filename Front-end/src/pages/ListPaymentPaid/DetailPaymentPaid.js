import React, { useEffect, useState } from 'react';
import './DetailPayment.css';
import { claimPayment } from '../../services/Admin/ApiPayment/Payment';

const DetailPayment = (props) => {
    const [isOpen, setIsOpen] = useState(true);
    const [payment, setPayment] = useState({});
    useEffect(() => {
        setIsOpen(true);
    }, [isOpen]);
    const closeDetail = () => {
        props.hidden(true);
    };
    const handlePayment = async () => {
        console.log(props.claim.id);
        await claimPayment(props.claim.id);
        closeDetail();
    };
    return (
        <>
            {props.claim && (
                <div id="deltai-payment-container">
                    <div>
                        <div className="top-section">
                            <h1>Thông tin đơn hàng</h1>
                            <div className="info">
                                <div className="column">
                                    <p>
                                        <strong>ID: </strong> {props.claim['id']}
                                    </p>
                                    <p>
                                        <strong>Ngày tạo:</strong> {props.claim['createdDate']}
                                    </p>
                                    <p>
                                        <strong>Tổng chi phí:</strong>
                                        {props.claim['totalCost']}
                                    </p>
                                    <p>
                                        <strong>Trạng thái:</strong> {props.claim['status']}
                                    </p>
                                </div>
                                <div className="column">
                                    <p>
                                        <strong>Khách hàng:</strong> {props.claim['customer']}
                                    </p>
                                    <p>
                                        <strong>CCCD:</strong> {props.claim['cccd']}
                                    </p>
                                    <p>
                                        <strong>Bảo hiểm:</strong> {props.claim['product']}
                                    </p>
                                    <p>
                                        <strong>Chương trình:</strong> {props.claim['program']}
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div className="bottom-section">
                            <div className="claim">
                                <h2>Danh sách yêu cầu trả tiền bảo hiểm</h2>
                                <table>
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Dịch vụ</th>
                                            <th>Chi phí điều trị</th>
                                            <th>Tên bệnh viện</th>
                                            <th>Ngày sử dụng</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {props.claim['claims'].length > 0 ? (
                                            props.claim['claims'].map((claim) => (
                                                <tr>
                                                    <td>{props.claim['claims'].indexOf(claim) + 1}</td>
                                                    <td>{claim['serviceName']}</td>
                                                    <td>{claim['costOfATreatment']}</td>
                                                    <td>{claim['hospitalName']}</td>
                                                    <td>{claim['usedDate']}</td>
                                                </tr>
                                            ))
                                        ) : (
                                            <p></p>
                                        )}
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div className="button-container">
                            <button className="view-button" onClick={() => closeDetail()}>
                                Đóng
                            </button>
                        </div>
                    </div>
                </div>
            )}
        </>
    );
};

export default DetailPayment;
