import axios from '../axios-customize';

export const PaymentApi = async (amount, orderId, orderName) => {
    return axios.post('/payment/momo-payment', { amount, orderId, orderName });
};