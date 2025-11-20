import axios from 'axios';

const jwt = localStorage.getItem('token');

const GetClaimByStatus = (status) => {
    return axios.get(`https://localhost:7112/api/claim/status/${status}`, {
        headers: 'Bearer ' + jwt,
    });
};

const addClaimPayment = (data) => {
    return axios.post(`https://localhost:7112/api/claim/payment`, data, {
        headers: 'Bearer ' + jwt,
    });
};

const denyRequest = (idRequest) => {
    return axios.put(`https://localhost:7112/api/claim?requestId=${idRequest}`, {
        headers: 'Bearer ' + jwt,
    });
};

export { GetClaimByStatus, addClaimPayment, denyRequest };
