import axios from '../axios-customize';
import Axios from 'axios'

const AccountCustomerApi = async (email) => {
    return axios.get(`/customer/${email}`);
};

const AccountEmployeeApi = async (email) => {
    return axios.get(`/Employee/${email}`);
};

const ContractsCustomerApi = async (CustomerId, status) => {
    return axios.get(`Contract/${CustomerId}/status/${status}`);
};

const UpdateCustomerApi = async (CustomerId, customer) => {
    return axios.put(`/customer?customerId=${CustomerId}`, customer);
};

const totalFeeByYearApi = async (customerId, year) => {
    return Axios.get(`https://localhost:7112/customer/${customerId}/report/${year}`);
};

const totalFeeForRequestApi = async (customerId) => {
    return axios.get(`/claim/payment/${customerId}/report`);
};



export {
    AccountCustomerApi, ContractsCustomerApi, UpdateCustomerApi, AccountEmployeeApi, totalFeeByYearApi, totalFeeForRequestApi
};

