import axios from 'axios';

const instance = axios.create({
    baseURL: 'https://localhost:7112/api',
});

instance.interceptors.response.use(
    function (response) {
        return response.data;
    },
    function (error) {
        let res = {};
        if (error.response) {
            console.log(error.response);
            res.data = error.response.data;
            res.status = error.response.status;
            res.headers = error.response.headers;
        } else if (error.request) {
            console.log('Error', error.request);
        } else {
            console.log('Error', error.message);
        }
        return res;
    },
);

export default instance;
