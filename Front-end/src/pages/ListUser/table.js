import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { RegistersApi } from '../../services/Admin/ApiRegister/register';
import { CustomersApi } from '../../services/Admin/ApiCustomer/customer';

function Table() {
    const navigate = useNavigate();
    const [register, setRegister] = useState([]);
    const [showForm, setShowForm] = useState(false);
    const [customer, setCustomer] = useState({});
    const [registerofCustomer, setRegisterOfCustomer] = useState([]);
    const [listCustomer, setListCustomer] = useState([]);
    const [checkStatus, setCheckStatus] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await RegistersApi();
                const res = await CustomersApi();
                setRegister(response);
                setListCustomer(res);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, []);

    const handleView = (id) => {
        let customer_detail = [];
        for (let i = 0; i < register.length; i++) {
            if (register[i].customer.customerId === id) {
                customer_detail = register[i].customer;
                break;
            }
        }
        let register_Customer = [];
        for (let i = 0; i < register.length; i++) {
            if (register[i].customer.customerId === customer_detail.customerId) {
                register_Customer.push(register[i]);
            }
        }
        setRegisterOfCustomer(register_Customer);
        setCustomer(customer_detail);
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
                            <b style={{ fontSize: '25px' ,color:'green'}}>Danh sách Khách hàng</b>
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
                                            Thông tin Khách hàng
                                        </span>
                                        {customer ? (
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
                                                                <strong>Khách hàng</strong>
                                                            </td>
                                                            <td>{customer.name}</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>Ngày sinh</strong>
                                                            </td>
                                                            <td>{customer.birthday}</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>Địa chỉ</strong>
                                                            </td>
                                                            <td>{customer.address}</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>email</strong>
                                                            </td>
                                                            <td>{customer.email}</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>CMND/CCCD</strong>
                                                            </td>
                                                            <td>
                                                                <span style={{ border: '0px' }}>
                                                                    {customer.identifycationNumber}
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>Số điện thoại</strong>
                                                            </td>
                                                            <td>{customer.phoneNumber}</td>
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
                                                Thông tin bảo hiểm khách hàng đã đăng ký
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
                                                        <th>Bảo hiểm </th>
                                                        <th>Chương trình</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    {registerofCustomer.length > 0 ? (
                                                        registerofCustomer.map((curElem, i) => (
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
                                                                        {curElem.productName}
                                                                    </span>
                                                                </td>
                                                                <td
                                                                    style={{
                                                                        textAlign: 'center',
                                                                        maxWidth: '98px',
                                                                        margin: 'auto',
                                                                    }}
                                                                >
                                                                    <span>{curElem.programName}</span>
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
                        <table className="table table-striped table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Tên</th>
                                    <th>CMND/CCCD</th>
                                    <th>Email</th>
                                    <th>Số điện thoại</th>
                                    <th>Địa chỉ</th>
                                    <th>Ngày sinh</th>
                                </tr>
                            </thead>
                            <tbody>
                                {listCustomer && listCustomer.length > 0 ? (
                                    listCustomer.map((curElem, i) => (
                                        <tr key={curElem.customerId}>
                                            <td>{i + 1}</td>
                                            <td>{curElem.name}</td>
                                            <td>{curElem.identifycationNumber}</td>
                                            <td>{curElem.email}</td>
                                            <td>{curElem.phoneNumber}</td>
                                            <td>{curElem.address}</td>
                                            <td>{curElem.birthday}</td>

                                            <td>
                                                <span
                                                    onClick={() => handleView(curElem.customerId)}
                                                    className="view mx-auto"
                                                    title="View"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'orange' }}
                                                >
                                                    <i className="material-icons">&#xE417;</i>
                                                </span>
                                            </td>
                                        </tr>
                                    ))
                                ) : (
                                    <tr style={{ textAlign: 'center' }}>
                                        <td colSpan="10">Danh sách rỗng</td>
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
