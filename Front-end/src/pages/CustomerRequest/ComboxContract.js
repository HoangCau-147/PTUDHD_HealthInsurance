import {ContractsCustomerApi} from "../../services/ApiAccount/Account";
import React, { useState, useEffect } from 'react';
import './style.scss';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function ComboxContract (props) {
    const customerId = props.customerId;
    const [Contract, setContract] = useState([]);

    const handleSelectChange = (event) => {
        const selectedValue = event.target.value;
        props.onSelectChange(selectedValue);
    };


    useEffect (() => {
        const fetchContract = async () => {
            try {
                console.log("customer ID" + customerId);
                const contractResponse = await ContractsCustomerApi(customerId,2)
                .then((res) =>{
                    console.log("contract", res); 
                    setContract(res);
                    
                })
            }
            catch (error) {
                console.error('Error fetching customer information:', error);
            }
        }
        if(customerId)
        {
            fetchContract(); 
        } 
    },[]);

    return (
    <div>
        <select onChange={handleSelectChange}>
            <option className="opt-1" disabled selected>---------------------------</option>
            { Array.isArray(Contract) && Contract.length > 0 ? (
            Contract.map(contract => (
            <option key={contract.contractId} value={contract.contractId}>{contract.productName} - {contract.programName}</option>
            // Thay 'name' và 'id' bằng các trường thực tế trong đối tượng hợp đồng
            ))) : (
                <option>Không có hợp đồng nào được tìm thấy</option>
            )}
        </select>
    </div>
    );
}

export default ComboxContract;