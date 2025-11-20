import React, { useEffect, useState } from 'react';
import './styles.css';
import { DetailRegistersApi } from '../../services/Admin/ApiRegister/register';
import { useParams } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

const DetailContract = () => {
    const [contract, setContract] = useState({});
    const navigate = useNavigate();
    const role = localStorage.getItem('role');
    const { id } = useParams();
    useEffect(() => {
        
        if (role!=='Employee')
        {
        navigate('/');
        }
        const fetchData = async () => {
            try {
                console.log('check>>', id);
                const response = await DetailRegistersApi(id);
                console.log('check>>', response);
                setContract(response);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, [id]);

    return (
        <div style={{ paddingLeft: '260px' }}>
            <div style={{ height: '100px', width: '100%', textAlign: 'center', marginTop: '50px' }}>
                <span style={{ fontSize: '25px', color: 'green', paddingTop: '50px', fontWeight: 'bold' }}></span>
            </div>
            <div className="details">
                <div className="box">
                    <form>
                        <div className="row">
                            <label htmlFor="productName">Tên Bảo Hiểm</label>
                            <input type="text" id="productName" name="name" value={contract.productName} />
                        </div>
                        <div className="row">
                            <label htmlFor="productPrice">Price</label>
                            <input type="number" id="productPrice" name="price" value={100} />
                        </div>
                        <div className="row">
                            <label htmlFor="productDescription">Description</label>
                            <textarea id="productDescription" name="description" value={contract.programName} />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default DetailContract;
