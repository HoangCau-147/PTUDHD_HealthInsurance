import axios from '../../axios-customize';

const jwt = localStorage.getItem('token');

export const RegistersApi = () => {
    return axios.get('/Contract');
};
export const RegistersWithStatusApi = async (status) => {
    return axios.get(`/Contract/Status?status=${status}`);
};
export const RegistersUpdateStatusApi = async (contractId, status) => {
    try {
        if (!contractId || !status) {
            throw new Error("Invalid contractId or status");
        }

        if (!jwt) {
            throw new Error("Missing JWT token");
        }

        const response = await axios.post(`/Contract/updateStatus?contractId=${contractId}&status=${status}`, null, {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });

        return response.data;
    } catch (error) {
        if (error.response) {
            if (error.response.status === 403) {
                console.error("Lỗi 403 Forbidden:", error);
            } else {
                console.error("Lỗi kết nối:", error);
            }
        } else {
            throw error;
        }
    }
};
export const acceptRegistersApi = async (id) => {
    return axios.get('/Contract');
};
export const rejectRegistersApi = async (id) => {
    return axios.get('/Contract');
};
export const DetailRegistersApi = async (id) => {
    return axios.get(`/Contract/ContractId?Id=${id}`);
};
