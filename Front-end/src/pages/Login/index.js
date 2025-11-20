// Import your styles and image
import './style.scss';
import React, { useEffect, useState } from 'react';
import bgImg from '../../assets/image/img1.jpg';
import { LoginApi } from '../../services/ApiLogin/login';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    useEffect(() => {
        let token = localStorage.getItem('token');
        if (token) {
            navigate('/');
        }
    }, []);

    const handleClick = async () => {
        try {
            if (!email || !email.match(/^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/)) {
                toast.error('Please enter a valid email address');
                return;
            }

            if (!password) {
                toast.error('Password is required');
                return;
            }

            const response = await LoginApi(email, password);


            if (response && response.accessToken) {
                const token = response.accessToken;
                const role = response.role;
                await toast.success('Login Successfully!');
                localStorage.setItem('token', token);
                localStorage.setItem('role', role);
                if (role === "Customer") {
                    navigate('/');
                }
                else {
                    navigate('/admin');
                }

            } else if (response.data && response.data.status === 400) {
                toast.error(response.data.title);
                localStorage.setItem('token', '');
                localStorage.setItem('role', '');
            } else {
                if (response) {
                    toast.error(response.data.message);
                    localStorage.setItem('token', '');
                    localStorage.setItem('role', '');
                }
            }
        } catch (error) {
            console.error('Error submitting form:', error);
            toast.error('An unexpected error occurred. Please try again.');
        }
    };

    return (
        <section className="login-form">
            <div className="register">
                <div className="col-1">
                    <form id="form" className="flex flex-col">
                        <h2 className="title_signin">Sign In</h2>
                        <span>Welcome back to our website!</span>
                        <span className="underline" />
                        <input
                            type="email"
                            id="email"
                            name="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="Enter your email"
                        />
                        <input
                            type="password"
                            id="password"
                            name="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder="Enter your password"
                        />

                        <button type="button" className="btn" onClick={handleClick}>
                            Sign In
                        </button>
                        <ToastContainer />
                        <span className="underline" />
                        <p>
                            Don't have an account?{' '}
                            <a href="/signup" className="register-link">
                                Register
                            </a>
                        </p>
                    </form>
                </div>
                <div className="col-2">
                    <img style={{ borderRadius: '0px' }} src={bgImg} alt="" />
                </div>
            </div>
        </section>
    );
};

export default Login;
