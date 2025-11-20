import axios from 'axios';

const jwt = localStorage.getItem('token');

const GetClaimPayment = (status) => {
    return axios.get(`https://localhost:7112/api/claim/payment`, {
        headers: {
            Authorization: `Bearer ${jwt}`,
        },
    });
};
const claimPayment = (idPayment) => {
    return axios.put(`https://localhost:7112/api/claim/payment?paymentId=${idPayment}`, null, {
        headers: {
            Authorization: `Bearer ${jwt}`,
        },
    });
};

export { GetClaimPayment, claimPayment };
