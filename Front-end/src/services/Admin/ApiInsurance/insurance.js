import axios from '../../axios-customize';

export const InsurancesApi = () => {
    return axios.get('/InsuranceProduct');
};
export const addInsurancesApi = (
    policyName,
    insuredParty,
    territorialScope,
    participationProcedure,
    feeGuarantee,
    commitment,
    shortDescription,
    imageUrl,
    conditions,
    programPrices,
    benefitTypes,
) => {
    return axios.post('/InsuranceProduct', {
        policyName,
        insuredParty,
        territorialScope,
        participationProcedure,
        feeGuarantee,
        commitment,
        shortDescription,
        imageUrl,
        conditions,
        programPrices,
        benefitTypes,
    });
};
export const updateInsurancesApi = (
    productId,
    policyName,
    insuredParty,
    territorialScope,
    participationProcedure,
    feeGuarantee,
    commitment,
    shortDescription,
    imageUrl,
) => {
    return axios.put('/InsuranceProduct',{
        productId,
        policyName,
        insuredParty,
        territorialScope,
        participationProcedure,
        feeGuarantee,
        commitment,
        shortDescription,
        imageUrl,
    });
};
export const offInsurancesApi = () => {
    return axios.post('/InsuranceProduct');
};
export const getInsuranceByIdApi = (id) => {
    return axios.get(`/InsuranceProduct/${id}`);
};
export const deleteInsuranceApi=(productId) => {
    return axios.put(`/InsuranceProduct/disable/${productId}`);
}
