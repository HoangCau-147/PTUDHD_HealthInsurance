import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

import { RegistersWithStatusApi, RegistersUpdateStatusApi } from '../../services/Admin/ApiRegister/register';
import { toast } from 'react-toastify';

function Table() {
    const navigate = useNavigate();
    const [register, setRegister] = useState([]);
    const [registerDetail, setRegisterDetail] = useState({});
    const [showForm, setShowForm] = useState(false);
    const [checkUpdate, setcheckUpdate] = useState(false)

    useEffect(() => {
        const fetchData = async () => {
            try {
                const role = localStorage.getItem('role');
                if (role === "Employee") {
                    const response = await RegistersWithStatusApi(0);
                    setRegister(response);
                    setcheckUpdate(false);
                }
                else {
                    navigate('/ ');
                }

            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, [checkUpdate]); // Include register in the dependency array if you want to log changes

    const handleDelete = async (id) => {
        //call API
        try {

            await RegistersUpdateStatusApi(id, 1);
            toast.success("Hủy thành công");
            setcheckUpdate(true);
            navigate(`/admin/registers`);
        } catch (error) {
            console.error("Lỗi khi gọi API:", error);
            toast.error("Đã xảy ra lỗi khi gọi API");
        }
    };

    const handleAccept = async (id) => {
        //call API
        try {

            await RegistersUpdateStatusApi(id, 2);
            toast.success("Duyệt thành công");
            setcheckUpdate(true);
            navigate(`/admin/registers`);
        } catch (error) {
            console.error("Lỗi khi gọi API:", error);
            toast.error("Đã xảy ra lỗi khi gọi API");
        }

    };

    const handleView = (id) => {
        for (let i = 0; i < register.length; i++) {
            if (register[i].contractId === id) {
                setRegisterDetail(register[i]);
                break;
            }
        }
        setShowForm(!showForm);
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
                            <b style={{ fontSize: '25px' ,color:'green'}}>Danh sách đăng ký</b>
                        </h2>
                    </div>
                </div>
                <div class="row">
                    <div class="table-responsive ">
                        <div>
                            {showForm && (
                                <div className="overlay-register" style={{ paddingLeft: '260px' }}>
                                    <div
                                        className="form-container-register"
                                        style={{
                                            textAlign: 'center',
                                            height: '800px',
                                            width: '1000px',
                                            overflowY: 'auto',
                                        }}
                                    >
                                        <span
                                            onClick={() => setShowForm(false)}
                                            className="cancel"
                                            title="cancel"
                                            data-toggle="tooltip"
                                            style={{
                                                cursor: 'pointer',
                                                float: 'right',
                                                position: 'fixed',
                                                zIndex: '99',
                                                right: '20%',
                                            }}
                                        >
                                            <i class="material-icons close">&#xe5cd;</i>
                                        </span>
                                        <br></br>
                                        <span
                                            style={{
                                                fontSize: '20px',
                                                fontWeight: 'bold',
                                                color: '#16a317',
                                                textAlign: 'center',
                                            }}
                                        >
                                            Thông tin Đăng ký
                                        </span>
                                        {registerDetail.customer ? (
                                            <div style={{ textAlign: 'center' }}>
                                                <table
                                                    style={{
                                                        textAlign: 'left',
                                                        marginBottom: '16px',
                                                        width: '-webkit-fill-available',
                                                    }}
                                                >
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <strong>Nhân viên duyệt</strong>
                                                            </td>
                                                            <td>{registerDetail.employee}</td>
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

                                        <div
                                            style={{
                                                textAlign: 'center',
                                            }}
                                        >
                                            <span
                                                style={{
                                                    fontSize: '20px',
                                                    fontWeight: 'bold',
                                                    color: '#16a317',
                                                    textAlign: 'center',
                                                }}
                                            >
                                                Thông tin tình trạng sức khỏe của khách hàng
                                            </span>
                                            <table
                                                style={{
                                                    marginBottom: '16px',
                                                    width: '950px',
                                                }}
                                            >
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
                                                                    <span
                                                                        style={{
                                                                            width: '100%',
                                                                            whiteSpace: 'wrap',
                                                                            overflowX: 'wrap',
                                                                        }}
                                                                    >
                                                                        {curElem.conditionName}
                                                                    </span>
                                                                </td>
                                                                <td
                                                                    style={{
                                                                        textAlign: 'center',
                                                                        maxWidth: '98px',
                                                                        margin: 'auto',
                                                                    }}
                                                                >
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
                                    </div>
                                </div>
                            )}
                        </div>
                        <table class="table table-striped table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>STT</th>
                                    <th>Name </th>
                                    <th>Birthday</th>
                                    <th>Email</th>
                                    <th>Phone Number</th>
                                    <th>Gói bảo hiểm </th>
                                    <th>Chương trình Bảo Hiểm </th>
                                    <th>Ngày đăng ký </th>
                                    <th>Duyệt </th>
                                    <th>Xem chi tiết </th>
                                    <th>Xóa </th>
                                </tr>
                            </thead>
                            <tbody>
                                {register && register.length > 0 ? (
                                    register.map((curElem, index) => (
                                        <tr key={curElem.contractId}>
                                            <td>{index + 1}</td>
                                            <td>{curElem.customer.name}</td>
                                            <td>{curElem.customer.birthday}</td>
                                            <td>{curElem.customer.email}</td>
                                            <td>{curElem.customer.phoneNumber}</td>
                                            <td>{curElem.productName}</td>
                                            <td>{curElem.programName}</td>
                                            <td>Ngày đăng ký</td>
                                            <td>
                                                <span
                                                    onClick={() => handleAccept(curElem.contractId)}
                                                    className="delete "
                                                    title="Delete"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'green', cursor: 'pointer' }}
                                                >
                                                    <i class="material-icons check_circle_outline">&#xe92d;</i>
                                                </span>
                                            </td>
                                            <td>
                                                <span
                                                    onClick={() => handleView(curElem.contractId)}
                                                    className="view  mx-auto"
                                                    title="View"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'orange', cursor: 'pointer' }}
                                                >
                                                    <i className="material-icons">&#xE417;</i>
                                                </span>
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
