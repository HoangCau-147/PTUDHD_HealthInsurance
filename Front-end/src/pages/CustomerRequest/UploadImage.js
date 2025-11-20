import React, { useState, useRef } from 'react';
import './UploadImage';
import { AiFillFile, AiFillFileImage } from 'react-icons/ai';
import { MdCloudUpload, MdDelete } from 'react-icons/md';

const ImageLoad = (props) => {
    // const [image, setImage] = useState([]);
    // const [isImageChange, setIsImageChange] = useState(false);
    // const [fileName, setFileName] = useState('No selected file');
    // const handleFileChange = ({ target: { files } }) => {
    //     // if (files[0]) {
    //     //     const file = files[0];

    //     //     // Basic validation: Check if the file is an image
    //     //     if (file.type.startsWith('image/')) {
    //     //         setFileName(file.name);
    //     //         setImage(URL.createObjectURL(file));
    //     //     } else {
    //     //         // Handle the case where the selected file is not an image
    //     //         alert('Please select a valid image file.');
    //     //     }
    //     // }
    //     console.log(files);
    //     let listImg = image;
    //     console.log(files['length']);
    //     if(files['length'] > 0) {
    //         for(let i = 0; i < files['length']; i++) {
    //             listImg.push({"img": URL.createObjectURL(files[i]), "name": files[i].name})
    //         }
    //         console.log(listImg);
            
    //     }
    //     console.log(image);
    //     setImage(listImg); 
    //     setIsImageChange(true);
    // };
    // if(isImageChange) 
    //     setIsImageChange(false);
    // return (
    //     <main>
    //         <form className="image-field" onClick={() => document.querySelector('.input-field').click()}>
    //             <input type="file" accept="image/*" multiple className="input-field" hidden onChange={handleFileChange} />
    //             {image.length > 0 ? (
    //                 image.length <= 3 ? (
    //                     image.map(i => (
    //                         <div>
    //                             <img src={i.img} max-width={50} height={50} alt={"h"} />
    //                             <span className="upload-content">
    //                                 {i.name.length > 20 ? i.name.slice(0, 20) + '...' : i.name}
    //                                 {'  -  '}
    //                                 <MdDelete
    //                                     onClick={() => {
    //                                         setFileName('No selected File');
    //                                         setImage(null);
    //                                     }}
    //                                 ></MdDelete>
    //                             </span>
    //                         </div>
    //                     )) 
    //                 ) : (
    //                     <div>
    //                         <div>
    //                             <img src={image[0].img} max-width={50} height={50} alt={"h"} />
    //                             <span className="upload-content">
    //                                 {image[0].name.length > 20 ? image[0].name.slice(0, 20) + '...' : image[0].name}
    //                                 {'  -  '}
    //                                 <MdDelete
    //                                     onClick={() => {
    //                                         setFileName('No selected File');
    //                                         setImage(null);
    //                                     }}
    //                                 ></MdDelete>
    //                             </span>
    //                         </div>
    //                         <div>
    //                             <img src={image[1].img} max-width={50} height={50} alt={"h"} />
    //                             <span className="upload-content">
    //                                 {image[1].name.length > 20 ? image[1].name.slice(0, 20) + '...' : image[1].name}
    //                                 {'  -  '}
    //                                 <MdDelete
    //                                     onClick={() => {
    //                                         setFileName('No selected File');
    //                                         setImage(null);
    //                                     }}
    //                                 ></MdDelete>
    //                             </span>
    //                         </div>
    //                         <div>
    //                             <p>+{image.length - 2}</p>
    //                         </div>
    //                     </div>
                            
    //                 )
    //             ) : ( 
    //                 <>
    //                     <MdCloudUpload color="#1475cf" size={60} />
    //                     <p>Browse Files to upload</p>
    //                 </>
    //             )}
    //         </form>
    //         <section className="uploaded-row">
    //             <AiFillFileImage color="#1475cf" />
    //             <span className="upload-content">
    //                 {fileName.length > 20 ? fileName.slice(0, 20) + '...' : fileName}
    //                 {'  -  '}
    //                 <MdDelete
    //                     onClick={() => {
    //                         setFileName('No selected File');
    //                         setImage(null);
    //                     }}
    //                 ></MdDelete>
    //             </span>
    //         </section>
    //     </main>
    // );
    const [image, setImage] = useState(null);
    const [fileName, setFileName] = useState('No selected file');
    const handleFileChange = ({ target: { files } }) => {
        if (files[0]) {
            const file = files[0];

            // Basic validation: Check if the file is an image
            if (file.type.startsWith('image/')) {
                setFileName(file.name);
                // setImage(URL.createObjectURL(file));
                setImage(file);
            } else {
                // Handle the case where the selected file is not an image
                alert('Please select a valid image file.');
            }
        }
    };
    const getImage = () => {
        props.onSelectChange(image);
    }
    getImage();
    return (
        <main>
            <form className="image-field" onClick={() => document.querySelector('.input-field').click()}>
                <input type="file" accept="image/*" className="input-field" hidden onChange={handleFileChange} />
                {image ? (
                    <img src={URL.createObjectURL(image)} width={400} height={250} alt={fileName} />
                ) : (
                    <>
                        <MdCloudUpload color="#1475cf" size={60} />
                        <p>Browse Files to upload</p>
                    </>
                )}
            </form>
            <section className="uploaded-row">
                <AiFillFileImage color="#1475cf" />
                <span className="upload-content">
                    {fileName.length > 20 ? fileName.slice(0, 20) + '...' : fileName}
                    {'  -  '}
                    <MdDelete
                        onClick={() => {
                            setFileName('No selected File');
                            setImage(null);
                        }}
                    ></MdDelete>
                </span>
            </section>
        </main>
    );
};

export default ImageLoad;
