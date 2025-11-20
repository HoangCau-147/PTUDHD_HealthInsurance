import { React, useEffect, useState } from 'react';
import { RegistersWithStatusApi } from '../../services/Admin/ApiRegister/register';
import { CustomersApi } from '../../services/Admin/ApiCustomer/customer';
import { GetClaimPayment } from '../../services/Admin/ApiPayment/Payment';
import { HomeApi } from '../../services/ApiHome/home';

import './ListTag.scss';

const ListTag = () => {
    const [constractNum, setContractsNum] = useState(100);
    const [customerNum, setCustomerNum] = useState(100);
    const [requestNum, setRequestNum] = useState(100);
    const [insurancesNum, setInsurancesNum] = useState(100);
    const [claims, setClaim] = useState([]);
    const [, setPayment] = useState([{}]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await RegistersWithStatusApi(0);
                const res_cus = await CustomersApi();
                const res_insurances = await HomeApi();
                await GetClaimPayment(0)
                    .then((res) => {
                        let list_payment = [];
                        for (let i = 0; i < res.data.length; i++) {
                            if (res.data[i].status === 'UNPAID') {
                                list_payment.push(res.data[i]);
                            }
                        }
                        setContractsNum(response?.length || 0);
                        setCustomerNum(res_cus?.length || 0);
                        setInsurancesNum(res_insurances?.length || 0);
                        setRequestNum(list_payment?.length || 0);
                    })
                    .catch((err) => {
                        console.log(err);
                    });
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
        if (claims == []) {
            return setClaim([]);
        }
    }, []);
    return (
        <div className="listtag">
            <div className="tag">
                <span>{constractNum}</span>
                <label>Hợp đồng</label>
            </div>
            <div className="tag">
                <span>{customerNum}</span>
                <label>Khách hàng</label>
            </div>
            <div className="tag">
                <span>{requestNum}</span>
                <label>Yêu cầu chưa thanh toán </label>
            </div>
            <div className="tag">
                <span>{insurancesNum}</span>
                <label>Số lương bảo hiểm</label>
            </div>
        </div>
    );
};

export default ListTag;
