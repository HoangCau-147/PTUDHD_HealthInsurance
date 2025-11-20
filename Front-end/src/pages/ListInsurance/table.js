import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { InsurancesApi, deleteInsuranceApi } from '../../services/Admin/ApiInsurance/insurance';

function Table() {
    const navigate = useNavigate();
    const [insurance, setInsurance] = useState([]); // Correct usage of useState
    const [isButtonDisabled, setIsButtonDisabled] = useState(false);
    const [reload,setReload] =useState(false)

    useEffect(() => {
        const fetchData = async () => {
            try {
                const role = localStorage.getItem('role');
                if(role=="Employee"){const response = await InsurancesApi();
                console.log('check>>', response);
                setInsurance(response);}
                else{
                    navigate('/');
                }
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, [reload]); // Include register in the dependency array if you want to log changes

    const handleDelete = async(id) => {
        setIsButtonDisabled(true);
        //call API
        // navigate(`/admin/insurance`);
        console.log('id',id)
        try{
            await deleteInsuranceApi(id)
            console.log('response',id)
            toast.success('Xóa bảo hiểm thành công!');navigate(`/admin/insurances/`);
            setReload((prevReload) => !prevReload)
        }catch(error)
        {
            toast.error('Đã có lỗi xảy ra, vui lòng thực hiện lại')
            console.log("error:",error)
        }
        finally {
            // Kích hoạt lại nút sau khi xử lý hoàn tất
            setIsButtonDisabled(false);
            
        }

    };

    const handleUpdate = (id) => {
        //call API
        navigate(`/admin/users`);
    };

    const handleAdd = (id) => {
        //call API
        navigate(`/admin/add-insurances`);
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
                            <b style={{ fontSize: '25px' }}>Danh sách Bảo Hiểm</b>
                        </h2>
                    </div>
                    <div style={{ textAlign: 'right', paddingBottom: '10px', paddingRight: '30px' }}>
                        <button className="btn btn-success" style={{ fontSize: '15px' }} onClick={() => handleAdd()}>
                            Thêm
                        </button>
                    </div>
                </div>
                <div class="row">
                    <div class="table-responsive ">
                        <table className="table table-striped table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Tên bảo hiểm</th>
                                    <th>Số lượng đã bán</th>
                                    <th>Phạm vi</th>
                                    <th>Chỉnh sửa</th>
                                    <th>Xem chi tiết</th>
                                    <th>Vô hiệu</th>
                                </tr>
                            </thead>
                            <tbody>
                                {insurance && insurance.length > 0 ? (
                                    insurance.map((curElem) => (
                                        <tr key={curElem.productId}>
                                            <td>{curElem.productId}</td>
                                            <td>{curElem.policyName}</td>
                                            <td>{curElem.totalQuantitySold}</td>
                                            <td>{curElem.territorialScope}</td>
                                            <td>                                                
                                                <Link
                                                    to={`/admin/update-insurances/${curElem.productId}`}
                                                    className="view  mx-auto"
                                                    title="update"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'green' }}
                                                    aria-disabled={isButtonDisabled}
                                                >
                                                    <i className="material-icons">&#xe3c9;</i>
                                                    
                                                </Link>
                                            </td>
                                            <td>
                                                <Link
                                                    to={`/admin/detail-insurance/${curElem.productId}`}
                                                    className="view  mx-auto"
                                                    title="View"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'orange' }}
                                                    aria-disabled={isButtonDisabled}
                                                >
                                                    <i className="material-icons">&#xE417;</i>
                                                    
                                                </Link>
                                            </td>
                                            <td>
                                                <span
                                                    onClick={() => handleDelete(curElem.productId)}
                                                    className="delete"
                                                    title="Delete"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'red', cursor: 'pointer' }}
                                                    aria-disabled={isButtonDisabled}
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
