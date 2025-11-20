import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { Image } from 'cloudinary-react';
import './style.css';

const ImageUpload = async (image) => {
    // console.log(image);
    const data = new FormData();
    data.append('file', image);
    data.append('upload_preset', process.env.REACT_APP_CLOUDINARY_UPLOAD_PRESET);
    data.append('cloud_name', process.env.REACT_APP_CLOUDINARY_CLOUD_NAME);
    data.append('folder', 'Cloudinary-React');
    // for (var key of data.entries()) {
    //     console.log(key[0] + ', ' + key[1]);
    // }
    try {
        const response = await fetch(
            `https://api.cloudinary.com/v1_1/${process.env.REACT_APP_CLOUDINARY_CLOUD_NAME}/image/upload`,
            {
                method: 'POST',
                body: data,
            },
        );
        const res = await response.json();
        console.log(res);
        return res.public_id;

        // await axios.post(`https://api.cloudinary.com/v1_1/${process.env.REACT_APP_CLOUDINARY_CLOUD_NAME}/image/upload`, data, {
        //     headers: {
        //         "Content-Type": "multiform/form-data"
        //     }
        // }).then((res) => {
        //     console.log(res.status);
        //     return res.data
        // }).catch(error =>  {
        //     console.log(error);
        //     return "";
        // })
    } catch (error) {
        console.log(error);
        return '';
    }
};

// const PreviewImage = (props) => {
//     if(props.url != "") {
//         const loading = false;
//         return (
//             <div>
//                 {loading ? (
//                     <div className="flex items-center justify-center gap-2">
//                         <div className="border-t-transparent border-solid animate-spin rounded-full border-blue-400 border-4 h-6 w-6"></div>
//                         <span>Processing...</span>
//                     </div>
//                 ) : (
//                     props.url && (
//                         <div className="pb-8 pt-4">
//                             <Image cloudName={process.env.REACT_APP_CLOUDINARY_CLOUD_NAME} publicId={props.url} />
//                         </div>
//                     )
//                 )}
//             </div>
//         );
//     }
// };

const PreviewImage = (props) => {
    const [isOpen, setIsOpen] = useState(true);
    useEffect(() => {
        setIsOpen(true);
    }, []);
    const closeImage = () => {
        setIsOpen(false);
        props.hidden(true);
    };

    if (props.url != '' && isOpen) {
        return (
            <div className={`preview-image ${isOpen ? 'open' : 'closed'}`}>
                {
                    //   <div className="overlay" onClick={closeImage}>
                    <div className="image">
                        {props.url && (
                            <div >
                                <Image cloudName={process.env.REACT_APP_CLOUDINARY_CLOUD_NAME} publicId={props.url} />
                            </div>
                        )}
                    </div>
                    //   </div>
                }
                <button className="close-btn-img" onClick={() => closeImage()}>
                    Close
                </button>
            </div>
        );
    }
    return (
        <div>
            <span>không có ảnh</span>
        </div>
    ); // Trả về null nếu không có URL ảnh
};

export { ImageUpload, PreviewImage };
