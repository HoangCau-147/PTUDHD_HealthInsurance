import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { CustomersApi } from '../../services/Admin/ApiCustomer/customer';
import './table.scss';
function Table() {
    const navigate = useNavigate();
    const [register, setRegister] = useState([]); // Correct usage of useState
    const role = localStorage.getItem('role');

    useEffect(() => {
        const fetchData = async () => {
            try {
                if (role === 'Customer') {
                    navigate('/');
                } else {
                    const res = await CustomersApi();
                    setRegister(res);
                }
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, []);

    return (
        <>
            <div class="row_table">
                <div class="table-responsive ">
                    <table class="table table-striped table-hover table-bordered">
                        <thead>
                            <tr>
                                <th>ID </th>
                                <th>Name</th>
                                <th>Email</th>
                                <th>Số điện thoại</th>
                            </tr>
                        </thead>
                        <tbody>
                            {register && register.length > 0 ? (
                                register.slice(0, 7).map((curElem, i = 0) => (
                                    <tr key={curElem.customerId}>
                                        <td>{i + 1}</td>
                                        <td>{curElem.name}</td>
                                        <td>{curElem.email}</td>
                                        <td>{curElem.phoneNumber}</td>

                                        <td style={{ textAlign: 'center' }}>
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
        </>
    );
}

export default Table;
