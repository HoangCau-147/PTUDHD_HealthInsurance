import 'bootstrap/dist/css/bootstrap.min.css';
import { PreviewImage } from '../../helpers/ImageHelper';
import { useEffect, useState } from 'react';
import { GetClaimPayment } from '../../services/Admin/ApiPayment/Payment';
import { Link, useNavigate } from 'react-router-dom';
import DetailPayment from './DetailPayment';

function Table() {
    const [claims, setClaim] = useState([]);
    const [PaymentChange, setPaymentChange] = useState(false);
    const [isHiddenForm, setIsHiddenForm] = useState(true);
    const [claimPayment, setclaimPayment] = useState('');
    const [reload, setReload] = useState(false);
    const [payment, setPayment] = useState([{}]);

    useEffect(() => {
        const fetchClaim = async () => {
            await GetClaimPayment(0)
                .then((res) => {
                    let list_payment = [];
                    for (let i = 0; i < res.data.length; i++) {
                        if (res.data[i].status === 'UNPAID') {
                            list_payment.push(res.data[i]);
                        }
                    }
                    setPayment(list_payment);
                    setClaim(res.data);
                    setPaymentChange(true);
                    console.log(list_payment.length);
                })
                .catch((err) => {
                    console.log(err);
                });
        };
        fetchClaim();
        if (claims == []) {
            return setClaim([]);
        }
        setReload(false);
    }, [reload]);
    const handleDateTimeType = (inputTimeString) => {
        // Tạo đối tượng Date từ chuỗi thời gian đầu vào
        const dateTime = new Date(inputTimeString);

        // Lấy ra giờ, phút và giây
        const hours = dateTime.getHours();
        const minutes = dateTime.getMinutes();
        const seconds = dateTime.getSeconds();

        // Lấy ra ngày, tháng và năm
        const day = dateTime.getDate();
        const month = dateTime.getMonth() + 1; // Tháng bắt đầu từ 0, cần cộng thêm 1
        const year = dateTime.getFullYear();

        // Định dạng lại chuỗi theo định dạng mong muốn
        const formattedTimeString = `${hours}:${minutes}:${seconds} ${day}-${month}-${year}`;
        return formattedTimeString;
    };

    const handleEnableForm = (value) => {
        setIsHiddenForm(false);
        //console.log(value.id);
        setclaimPayment(value);
    };
    const handleHiddenForm = (value) => {
        setIsHiddenForm(value);
        setReload(true);
    };

    return (
        <div class="container">
            <div className="crud shadow-lg p-3 mb-5 mt-5 bg-body rounded">
                <div class="row ">
                    <div class="col-sm-3 mt-5 mb-4">
                        <div className="search">
                            <form class="form-inline">
                                <input
                                    class="form-control mr-sm-2 rounded-pill border border-success"
                                    type="search"
                                    placeholder="Search User"
                                    aria-label="Search"
                                    style={{ height: '40px', fontSize: '15px', backgroundColor: 'white' }}
                                />
                            </form>
                        </div>
                    </div>
                    <div class="col-sm-6  mt-5 mb-4 text-center">
                        <h2>
                            <b style={{ fontSize: '25px', color:'green'}}>Thanh toán phiếu yêu cầu</b>
                        </h2>
                    </div>
                </div>
                <div class="row">
                    <div class="table-responsive ">
                        {/* {!isHiddenForm && <FormAddClaimPayment claim={claimRequest} hidden={handleHiddenForm}></FormAddClaimPayment>} */}
                        {!isHiddenForm && (
                            <DetailPayment claim={claimPayment} hidden={handleHiddenForm}></DetailPayment>
                        )}
                        <table class="table table-striped table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>STT</th>
                                    <th>Khách hàng</th>
                                    <th>Bảo hiểm</th>
                                    <th>Chương trình</th>
                                    <th>Ngày Gửi</th>
                                    <th>Trạng thái</th>
                                    <th>Chi tiết thanh toán</th>
                                </tr>
                            </thead>
                            <tbody>
                                {payment.length > 0 ? (
                                    payment.map((claim) => (
                                        <tr>
                                            <td>{claims.indexOf(claim) + 1}</td>
                                            <td>{claim['customer']}</td>
                                            <td>{claim['product']}</td>
                                            <td>{claim['program']}</td>
                                            <td>{handleDateTimeType(claim['createdDate'])}</td>
                                            <td>{claim['status']}</td>
                                            <td>
                                                <button className="view-button" onClick={() => handleEnableForm(claim)}>
                                                    Xem
                                                </button>
                                            </td>
                                            {/* <td>
                                                <Link onClick={() => handleEnableForm(claim)}>
                                                    <i className="material-icons">&#xE417;</i>
                                                </Link>
                                            </td> */}
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan="10" style={{ textAlign: 'center' }}>
                                            Danh sách rỗng
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Table;
