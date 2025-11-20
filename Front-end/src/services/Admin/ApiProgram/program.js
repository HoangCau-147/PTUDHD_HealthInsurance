import axios from '../../axios-customize';

export const ProgramApi = () => {
    return axios.get('/InsuraceProgram');
};
