import axios from '../axios-customize';

const RegisterProductApi = async (productId) => {
    return axios.get(`/InsuranceProduct/${productId}`);
};

const RegisterCustomerApi = async (email) => {
    return axios.get(`/customer/${email}`);
};

const RegisterContractApi = async (productId, programId, startDate, endDate, totalPrice, healthDeclaration, paymentMethod, customer, healthConditions) => {
    return axios.post(`/Contract`, { productId, programId, startDate, endDate, totalPrice, healthDeclaration, paymentMethod, customer, healthConditions });
};

export {
    RegisterProductApi, RegisterCustomerApi, RegisterContractApi
};