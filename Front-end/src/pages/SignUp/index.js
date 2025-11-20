// Import your styles and image
import classNames from 'classnames/bind';
import styles from './Signup.module.scss';
import React, { useState } from 'react';
import bgImg from '../../assets/image/img1.jpg';
import { SignupApi } from '../../services/ApiSignUp/signup';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom';

const Register = () => {
    const navigate = useNavigate();
    const [userName, setUserName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [name, setName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [birthday, setBirthday] = useState('');
    const [address, setAddress] = useState('');
    const [identifycationNumber, setIdentifycationNumber] = useState('');

    const handleClick = async () => {
        try {
            //Validate userName
            if (!userName) {
                toast.error('User Name is required');
                return;
            }

            //Validate email
            if (!email || !email.match(/^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/)) {
                toast.error('Please enter a valid email address');
                return;
            }

            // Validate password
            if (
                !password ||
                !password.match(/^(?=.*[a-zA-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[A-Za-z\d][A-Za-z\d!@#$%^&*()_+]{7,19}$/)
            ) {
                toast.error(
                    'Password must be 7-19 characters and contain at least one letter, one number and a special character',
                );
                return;
            }

            // Validate name
            if (!name) {
                toast.error('Name is required');
                return;
            }

            // Validate phoneNumber
            if (!phoneNumber) {
                toast.error('Phone number is required');
                return;
            }

            // Validate birthday
            if (!birthday) {
                toast.error('Birthday is required');
                return;
            }

            // Validate address
            if (!address) {
                toast.error('Address is required');
                return;
            }

            // Validate identificationNumber
            if (!identifycationNumber) {
                toast.error('Identification number is required');
                return;
            }

            // Assigning roles and additional user data
            const fullBirthday = birthday + 'T04:53:59.325Z';
            const roles = ['Customer'];

            const response = await SignupApi(
                userName,
                password,
                email,
                roles,
                name,
                identifycationNumber,
                fullBirthday,
                phoneNumber,
                address,
            );
            if (response.response && response.response.status === 'Success') {
                await toast.success(response.response.message + '. Please confirm your email to login!');
                navigate('/login');
            } else {
                if (response && response.status) {
                    toast.error(response.data.message);
                }
                console.log('Empty response:', response);
            }
        } catch (error) {
            console.error('Error submitting form:', error);
        }
    };

    const cx = classNames.bind(styles);

    return (
        <section className={cx('register-form')}>
            <div className={cx('register')}>
                <div className={cx('col-1')}>
                    <h2 style={{ textTransform: 'uppercase', fontWeight: '800', color: '#126131' }}>Sign Up</h2>
                    <span style={{ color: '#126131' }}>Create a new account!</span>

                    <form id={cx('form')} className={cx('flex', 'flex-col')}>
                        <input
                            type="text"
                            id={cx('userName')}
                            name="email"
                            value={userName}
                            onChange={(e) => setUserName(e.target.value)}
                            placeholder="Enter your UserName"
                        />
                        <input
                            type="email"
                            id={cx('email')}
                            name="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="Enter your email"
                        />
                        <input
                            type="password"
                            id={cx('password')}
                            name="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder="Enter your password"
                        />
                        <input
                            type="text"
                            id={cx('name')}
                            name="name"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            placeholder="Enter your name"
                        />
                        <input
                            type="tel"
                            id={cx('phoneNumber')}
                            name="phoneNumber"
                            value={phoneNumber}
                            onChange={(e) => setPhoneNumber(e.target.value)}
                            placeholder="Enter your phone number"
                        />
                        <input
                            type="date"
                            id={cx('birthday')}
                            name="birthday"
                            value={birthday}
                            onChange={(e) => setBirthday(e.target.value)}
                            placeholder="Enter your birthday"
                        />
                        <input
                            type="text"
                            id={cx('address')}
                            name="address"
                            value={address}
                            onChange={(e) => setAddress(e.target.value)}
                            placeholder="Enter your address"
                        />
                        <input
                            type="text"
                            id={cx('identifycationNumber')}
                            name="identifycationNumber"
                            value={identifycationNumber}
                            onChange={(e) => setIdentifycationNumber(e.target.value)}
                            placeholder="Enter your identification number"
                        />

                        <button type="button" className={cx('btn')} onClick={handleClick}>
                            Sign Up
                        </button>
                        <ToastContainer />
                        <span className={cx('underline')} />
                        <p>
                            Already have an account?{' '}
                            <a href="/login" className={cx('login-link')}>
                                Log In
                            </a>
                        </p>
                    </form>
                </div>
                <div className={cx('col-2')}>
                    <img
                        src={bgImg}
                        alt=""
                        className={cx('form-image')}
                        style={{ height: '1068.03px', borderRadius: '0px' }}
                    />
                </div>
            </div>
        </section>
    );
};

export default Register;
