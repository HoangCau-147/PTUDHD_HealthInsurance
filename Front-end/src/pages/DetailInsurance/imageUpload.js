import React, { useState } from 'react';
import './ImageUpload.css';
import { AiFillFileImage } from 'react-icons/ai';
import { MdCloudUpload, MdDelete } from 'react-icons/md';

const ImageUpload = () => {
    const [image, setImage] = useState(null);
    const [fileName, setFileName] = useState('No selected file');
    const handleFileChange = ({ target: { files } }) => {
        if (files[0]) {
            const file = files[0];

            // Basic validation: Check if the file is an image
            if (file.type.startsWith('image/')) {
                setFileName(file.name);
                setImage(URL.createObjectURL(file));
            } else {
                // Handle the case where the selected file is not an image
                alert('Please select a valid image file.');
            }
        }
    };
    return (
        <main>
            <form className="image-field" onClick={() => document.querySelector('.input-field').click()}>
                <input type="file" accept="image/*" className="input-field" hidden onChange={handleFileChange} />
                {image ? (
                    <img src={image} width={400} height={250} alt={fileName} />
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

export default ImageUpload;
