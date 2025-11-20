import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from 'react';
import { benefitsApi, addIBenefitApi, addIBenefitTypeApi } from '../../services/Admin/ApiBenefit/benefit';
import './styles.css';

function Table() {
    const [benefitDetail, setBenefitDetail] = useState({});
    const [benefit, setBenefit] = useState([]);
    const [newName, setNewName] = useState('');
    const [newDescription, setNewDescription] = useState('');
    const [showForm, setShowForm] = useState(false);
    const [showForm2, setShowForm2] = useState(false);
    const [showForm3, setShowForm3] = useState(false);
    const [selectedBenefitType, setSelectedBenefitType] = useState('');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await benefitsApi();
                console.log('check>>', response);
                setBenefit(response);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, [showForm2]); // Include register in the dependency array if you want to log changes

    const handleView = (id) => {
        for (let i = 0; i < benefit.length; i++) {
            if (benefit[i].benefitTypeId === id) {
                setBenefitDetail(benefit[i]);
                break;
            }
        }
        setShowForm3(!showForm3);
    };

    const handleAddBenefitType = (id) => {
        setShowForm2(!showForm2);
    };

    const handleAdd = (benefitTypeId) => {
        setSelectedBenefitType(benefitTypeId);
        setShowForm(!showForm);
    };

    const handleAddClick = async () => {
        // Validate if newName and newDescription are not empty
        if (newName.trim() === '' || newDescription.trim() === '') {
            // Display an error message or take appropriate action
            return;
        }

        // Create a new row object
        const Benefit_input = {
            benefitTypeId: selectedBenefitType, // This uses selectedBenefitType
            name: newName,
            description: newDescription,
            // ... other properties as needed
        };

        console.log(Benefit_input);
        await addIBenefitApi(Benefit_input.benefitTypeId, Benefit_input.name, Benefit_input.description);

        // Reset input values and hide the form
        setNewName('');
        setNewDescription('');
        setShowForm(false);
    };
    const handleAddClick2 = async () => {
        if (newName.trim() === '') {
            return;
        }

        const BenefitType_input = {
            name: newName,
            benefits: [],
        };

        await addIBenefitTypeApi(BenefitType_input.name, BenefitType_input.benefits);

        setNewName('');
        setShowForm2(false);
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
                                    placeholder="Search Benefit"
                                    aria-label="Search"
                                    style={{ height: '40px', fontSize: '15px', backgroundColor: 'white' }}
                                />
                            </form>
                        </div>
                    </div>
                    <div class="col-sm-3 offset-sm-2 mt-5 mb-4 text-gred" style={{ color: 'green' }}>
                        <h2>
                            <b style={{ fontSize: '25px' }}>Danh sách Lợi ích</b>
                        </h2>
                    </div>
                    <div style={{ textAlign: 'right', paddingBottom: '10px', paddingRight: '30px' }}>
                        <button
                            className="btn btn-success"
                            style={{ fontSize: '15px' }}
                            onClick={() => handleAddBenefitType()}
                        >
                            Thêm
                        </button>
                    </div>
                </div>
                <div class="row">
                    <div class="table-responsive ">
                        <div>
                            {showForm && (
                                <div className="overlay" style={{ paddingLeft: '260px' }}>
                                    <div
                                        className="form-container2"
                                        style={{
                                            width: '460px',
                                        }}
                                    >
                                        <span
                                            onClick={() => setShowForm(false)}
                                            className="cancel1"
                                            title="cancel"
                                            data-toggle="tooltip"
                                            style={{
                                                cursor: 'pointer',
                                                position: 'auto',
                                                float:'inline-end'
                                                
                                            }}
                                        >
                                            <i class="material-icons close">&#xe5cd;</i>
                                        </span>
                                        <br></br>
                                        <label>Name:</label>
                                        <input
                                            type="text"
                                            value={newName}
                                            onChange={(e) => setNewName(e.target.value)}
                                        />

                                        <label>Description:</label>
                                        <input
                                            type="text"
                                            value={newDescription}
                                            onChange={(e) => setNewDescription(e.target.value)}
                                        />

                                        <div className="button-container">
                                            <button onClick={handleAddClick} style={{ backgroundColor: '#16a317' }}>
                                                Add
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            )}
                            {showForm2 && (
                                <div className="overlay" style={{ paddingLeft: '260px' }}>
                                    <div
                                        className="form-container2"
                                        style={{
                                            width: '460px',
                                        }}
                                    >
                                        <span
                                            onClick={() => setShowForm2(false)}
                                            className="cancel"
                                            title="cancel"
                                            data-toggle="tooltip"
                                            style={{
                                                cursor: 'pointer',
                                                float: 'right',
                                                position: 'fixed',
                                                zIndex: '99',
                                                right: '32%',
                                            }}
                                        >
                                            <i class="material-icons close">&#xe5cd;</i>
                                        </span>
                                        <br></br>
                                        <label>Name:</label>
                                        <input
                                            type="text"
                                            value={newName}
                                            onChange={(e) => setNewName(e.target.value)}
                                        />

                                        <div className="button-container">
                                            <button onClick={handleAddClick2} style={{ backgroundColor: '#16a317' }}>
                                                Add
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            )}
                            {showForm3 && (
                                <div className="overlay" style={{ paddingLeft: '260px' }}>
                                    <div className="form-container2">
                                        <span
                                            onClick={() => setShowForm3(false)}
                                            className="close"
                                            title="cancel"
                                            data-toggle="tooltip"
                                            style={{
                                                cursor: 'pointer',
                                                position: 'auto',
                                                float:'inline-end'
                                            }}
                                        >
                                            <i class="material-icons close">&#xe5cd;</i>
                                        </span>
                                        <br></br>
                                        {benefitDetail ? (
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
                                                    {benefitDetail.name}
                                                </span>
                                                <br></br>
                                                <br></br>
                                                <br></br>
                                            </div>
                                        ) : (
                                            <p>Không có dữ liệu</p>
                                        )}

                                        <div
                                            style={{
                                                textAlign: 'center',
                                                width: '460px',
                                            }}
                                        >
                                            <div className='table-responsive'
                                            >
                                                <thead>
                                                    <tr>
                                                        <th>STT</th>
                                                        <th>Lợi ích</th>
                                                        <th>Mô tả</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    {benefitDetail.benefits.length > 0 ? (
                                                        benefitDetail.benefits.map((curElem, i) => (
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
                                                                        {curElem.benefitName}
                                                                    </span>
                                                                </td>
                                                                <td>
                                                                    <span>{curElem.description}</span>
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
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            )}
                        </div>

                        <table
                            className="table table-striped table-hover table-bordered"
                            style={{ textAlign: 'center' }}
                        >
                            <thead>
                                <tr>
                                    <th style={{ fontWeight: 'bold', fontSize: '15px' }}>STT</th>
                                    <th style={{ fontWeight: 'bold', fontSize: '15px' }}>Tên loại lợi ích</th>
                                    <th style={{ width: '200px', fontWeight: 'bold', fontSize: '15px' }}>
                                        Thêm lợi ích
                                    </th>
                                    <th style={{ width: '200px', fontWeight: 'bold', fontSize: '15px' }}>
                                        Xem chi tiết
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                {benefit && benefit.length > 0 ? (
                                    benefit.map((curElem, i = 0) => (
                                        <tr key={curElem.benefitTypeId}>
                                            <td>{i + 1}</td>
                                            <td>{curElem.name}</td>
                                            <td>
                                                <span
                                                    onClick={() => handleAdd(curElem.benefitTypeId)}
                                                    className="add mx-auto"
                                                    title="add"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'green', cursor: 'pointer' }}
                                                >
                                                    <i class="material-icons add_box">&#xe146;</i>
                                                </span>
                                            </td>
                                            <td>
                                                <span
                                                    onClick={() => handleView(curElem.benefitTypeId)}
                                                    className="view  mx-auto"
                                                    title="View"
                                                    data-toggle="tooltip"
                                                    style={{ color: 'orange', cursor: 'pointer' }}
                                                >
                                                    <i className="material-icons">&#xE417;</i>
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
