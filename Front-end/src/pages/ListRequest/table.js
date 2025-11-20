import 'bootstrap/dist/css/bootstrap.min.css';
import { PreviewImage } from '../../helpers/ImageHelper';
import { useEffect, useState } from 'react';
import { GetClaimByStatus, denyRequest } from '../../services/Admin/ApiRequest/request';
import { Link, useNavigate } from 'react-router-dom';
import { FormAddClaimPayment } from './FormAddClaimPayment';

import { toast } from 'react-toastify';

function Table() {
    const [claims, setClaim] = useState([]);
    const [claimsChange, setClaimChange] = useState(false);
    const [urlImg, setUrlImg] = useState('');
    const [isHiddenImg, setIsHiddenImg] = useState(true);
    const [isHiddenForm, setIsHiddenForm] = useState(true);
    const [claimRequest, setclaimRequest] = useState('');
    const [reload, setReload] = useState(false);

    useEffect(() => {
        const fetchClaim = async () => {
            await GetClaimByStatus(0)
                .then((res) => {
                    setClaim(res.data);
                    setClaimChange(true);
                    console.log(claims);
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
    const handlePreImg = (url) => {
        setUrlImg(url);
        setIsHiddenImg(false);
    };
    const handleHiddenImg = (value) => {
        setIsHiddenImg(value);
        setUrlImg('');
    };
    const handleEnableForm = (value) => {
        setIsHiddenForm(false);
        setclaimRequest(value);
    };
    const handleHiddenForm = (value) => {
        setIsHiddenForm(value);
        setReload(true);
    };
    const handleDeny = async (value) => {
        try {
            await denyRequest(value.claimRequestId);
            setReload(true);
            toast.success('Đã từ chối phiếu yêu cầu!');
        } catch (err) {
            toast.error('Không thể từ chối phiếu yêu cầu này!!');
        }
    };

    return (
        <div class="container">
            <div className="crud shadow-lg p-3 mb-5 mt-5 bg-body rounded">
                <div class="row ">
                    <div class="col-sm-3 mt-5 mb-4 text-gred">
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
                    <div class="col-sm-3 offset-sm-2 mt-5 mb-4 text-gred" style={{ color: 'green' }}>
                        <h2>
                            <b style={{ fontSize: '25px',color:'green' }}>Phiếu Yêu Cầu</b>
                        </h2>
                    </div>
                </div>
                <div class="row">
                    <div class="table-responsive ">
                        {!isHiddenForm && (
                            <FormAddClaimPayment claim={claimRequest} hidden={handleHiddenForm}></FormAddClaimPayment>
                        )}
                        {!isHiddenImg && <PreviewImage hidden={handleHiddenImg} url={urlImg} />}
                        <table class="table table-striped table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>STT</th>
                                    <th>Khách hàng</th>
                                    <th>Bảo hiểm</th>
                                    <th>Chương trình</th>
                                    <th>Ngày Gửi</th>
                                    <th>Trạng thái</th>
                                    <th>Hóa đơn</th>
                                    <th>Duyệt</th>
                                    <th>Từ chối</th>
                                </tr>
                            </thead>
                            <tbody>
                                {claims.length > 0 ? (
                                    claims.map((claim) => (
                                        <tr>
                                            <td>{claims.indexOf(claim) + 1}</td>
                                            <td>{claim['customerName']}</td>
                                            <td>{claim['productName']}</td>
                                            <td>{claim['programName']}</td>
                                            <td>{handleDateTimeType(claim['createdDate'])}</td>
                                            <td>{claim['status']}</td>
                                            <td>
                                                <button
                                                    className="view-button"
                                                    onClick={() => handlePreImg(claim['hospitalBillAmount'])}
                                                >
                                                    Xem
                                                </button>
                                            </td>
                                            <td>
                                                <Link onClick={() => handleEnableForm(claim)}>
                                                    <i className="material-icons">&#xE417;</i>
                                                </Link>
                                            </td>
                                            <td>
                                                <Link onClick={() => handleDeny(claim)}>
                                                    <i className="material-icons">&#xE872;</i>
                                                </Link>
                                            </td>
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
                            {/* <tbody>
                                {register && register.length > 0 ? (
                                    register.map((curElem) => (
                                        <tr key={curElem.contractId}>
                                            {
                                                <tr key={curElem.contractId}>
                                                    <td>{curElem.contractId}</td>
                                                    <td>{curElem.customer.name}</td>
                                                    <td>{curElem.customer.birthday}</td>
                                                    <td>{curElem.customer.email}</td>
                                                    <td>{curElem.customer.phoneNumber}</td>
                                                    <td>{curElem.productName}</td>
                                                    <td>{curElem.programName}</td>
                                                    <td>{curElem.dateRegister}</td>
                                                    <td>
                                                        <span
                                                            onClick={() => handleAccept(curElem.contractId)}
                                                            className="delete "
                                                            title="Delete"
                                                            data-toggle="tooltip"
                                                            style={{ color: 'green', cursor: 'pointer' }}
                                                        >
                                                            <i className="material-icons check_circle_outline">
                                                                &#xe92d;
                                                            </i>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <Link
                                                            to={`/view/${curElem.contractId}`}
                                                            className="view mx-auto"
                                                            title="View"
                                                            data-toggle="tooltip"
                                                            style={{ color: 'orange' }}
                                                        >
                                                            <i className="material-icons">&#xE417;</i>
                                                        </Link>
                                                    </td>
                                                    <td>
                                                        <span
                                                            onClick={() => handleDelete(curElem.contractId)}
                                                            className="delete"
                                                            title="Delete"
                                                            data-toggle="tooltip"
                                                            style={{ color: 'red', cursor: 'pointer' }}
                                                        >
                                                            <i className="material-icons">&#xE872;</i>
                                                        </span>
                                                    </td>
                                                </tr>
                                            }
                                        </tr>
                                    ))
                                ) : (
                                    <tr style={{ textAlign: 'center' }}>
                                        <td colSpan="10">Danh sách rỗng</td>
                                    </tr>
                                )}
                            </tbody> */}
                        </table>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Table;
