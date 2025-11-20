import './style.scss';
import React, { useState, useEffect } from 'react';
import { Image } from 'cloudinary-react';

import { GetCustomerInformation, PostClaimRequest } from '../../services/ApiCustomerRequest/CustomerRequest';
import ComboxContract from './ComboxContract';
import ImageLoad from './UploadImage';
import { ImageUpload } from '../../helpers/ImageHelper';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const AddCustomerRequest = (props) => {
    const [customer, setCustomer] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [image, setImage] = useState(null);
    const [url, setUrl] = useState('');
    //api
    // const [hospital, setHospital] = useState('');
    const [ContractId, setContractId] = useState('');

    const handleSelectContract = (value) => {
        setContractId(value);
    };
    const handleSelectImage = (value) => {
        setImage(value);
    };
    useEffect(() => {
        const fetchCustomerInformation = async () => {
            try {
                const response = await GetCustomerInformation().then((response) => {
                    if (response.status == 401) {
                        console.log('chưa đăng nhập');
                        // return window.location.replace("/login");
                    }
                    setCustomer(response);
                    setIsLoading(false);
                });
            } catch (error) {
                console.error('Error fetching customer information:', error);
            }
        };
        fetchCustomerInformation();
    }, []);

    const postRequest = (formdata) => {
        const resposne = async () => await PostClaimRequest(formdata);
        resposne().then(() => {
            toast.success("Tạo request thành công");
            handleClose();
        });
    };

    const handleSummitRequest = async () => {
        if (!ContractId) {
            document.querySelector('#contract-error').hidden = false;
        } else {
            document.querySelector('#contract-error').hidden = true;
        }
        if (!image) {
            document.querySelector('#img-error').hidden = false;
        } else {
            document.querySelector('#img-error').hidden = true;
        }
        if (ContractId && image && customer['customerId']) {
            const copyImg = image;
            const res = async (urlimg) => await ImageUpload(copyImg);
            res().then((res) => {
                console.log(res);
                    if (res) {
                        const formdata = {
                            ContractId: ContractId,
                            CustomerId: customer['customerId'],
                            HospitalBillAmount: res,
                        };
                        console.log(formdata);
                        const submitRequest =  async () => await postRequest(formdata);
                        submitRequest();
                    } else {
                        toast.error("Upload ảnh thất bại");
                    }
            });
            // console.log(urlimg);
            // if (urlimg) {
            //     const formdata = {
            //         ContractId: ContractId,
            //         CustomerId: customer['customerId'],
            //         HospitalBillAmount: urlimg,
            //     };
            //     console.log(formdata);
            //     await postRequest(formdata).then(() =>(
            //         toast.success("")
            //     ));
            // } else {
            //     console.log('Load Img unsuccessfully');
            // }
        }
    };
    const handleClose = () => {
        props.hidden(true);
    };

    if (customer['customerId']) {
        return (
            <div id="container">
                <div id="form-container">
                    <h1>Gửi yêu cầu</h1>
                    <p class="customer-info">
                        Khách hàng: {customer['name']} - ID: {customer['customerId']}
                    </p>
                    <label class="form-label">Chọn bảo hiểm:</label>
                    <ComboxContract
                        customerId={customer['customerId']}
                        onSelectChange={handleSelectContract}
                    ></ComboxContract>
                    <p id="contract-error" class="error-text" hidden>
                        Chưa chọn bảo hiểm
                    </p>
                    {/* <label class="form-label">
                        <p class="title-input">Bệnh viện: </p>
                        <input
                            id="input-hospital"
                            type="text"
                            value={hospital}
                            onChange={(hospital) => setHospital(hospital.target.value)}
                        />
                    </label> */}
                    <label class="form-label">Chọn ảnh hóa đơn:</label>
                    <ImageLoad onSelectChange={handleSelectImage}></ImageLoad>
                    <p id="img-error" class="error-text" hidden>
                        Chưa chọn hóa đơn
                    </p>
                    <div class="button-container">
                        <button class="close-button" onClick={handleClose}>
                            Đóng
                        </button>
                        <button class="submit-button" onClick={handleSummitRequest}>
                            Gửi yêu cầu
                        </button>
                    </div>
                </div>
            </div>
        );
    }
};

export default AddCustomerRequest;
