import React from 'react';
import './Payment.scss'; // Import file CSS để tùy chỉnh giao diện

const PaymentPage = () => {
    const handleMoMoPayment = () => {
        // Xử lý thanh toán bằng MoMo
        alert('momo');
    };

    const handleCODPayment = () => {
        // Xử lý thanh toán bằng COD
        alert('COD');

    };

    const handleVNPAYPayment = () => {
        // Xử lý thanh toán bằng VNPAY
        alert('VNPAY');
    };

    return (
        <div className="payment-container">
            <h1>Trang Thanh Toán</h1>
            <p>Chọn phương thức thanh toán:</p>

            <div className="payment-buttons">
                <button onClick={handleMoMoPayment}>Thanh Toán bằng MoMo</button>
                <button onClick={handleCODPayment}>Thanh Toán bằng COD</button>
                <button onClick={handleVNPAYPayment}>Thanh Toán bằng VNPAY</button>
            </div>
        </div>
    );
};

export default PaymentPage;