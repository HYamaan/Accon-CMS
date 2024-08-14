import React, {useEffect, useState} from 'react';
import axios from "axios";
import {LazyLoadImage} from "react-lazy-load-image-component";
import { getCookies, getCookie, setCookie, deleteCookie } from 'cookies-next';
import {toast} from "react-toastify";
import {useRouter} from "next/router";
const Login = () => {
    const router = useRouter();
    const [webSiteLogo, setWebSiteLogo] = useState('');
    const [loginBackground, setLoginBackground] = useState('');
    const [email, setEmail] = useState("admin@gmail.com");
    const [password, setPassword] = useState("Password@123");

    useEffect(() => {
        const getImages = async () => {
            const Images = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetLoginImages`);
            if (Images.data.succeeded) {
                console.log(Images.data);
                setWebSiteLogo(Images.data.data.webSiteLogo);
                setLoginBackground(Images.data.data.loginBackground);
            }
        }
        getImages();
    }, []);

    const handleLogin = async () => {
        console.log("Login Data: ", email)
        try {
            const login = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Cms/Login`, {
                email: email,
                password: password
            });
            if (login.data.succeeded) {
                const date = new Date(login.data.data.acaccessTokenExpiration);
                const accessTokenExpire = Math.floor(date.getTime() / 1000);
                deleteCookie('accessToken');
                setCookie('accessToken', login.data.data.accessToken, {
                    expires:accessTokenExpire
                });
                toast.success("Login Successfully");
                router.push('/admin');
            }
        } catch (e) {
            console.log(e);
        }
    }

    return (
        <div className="login-page">
            <LazyLoadImage
                src={loginBackground}
                alt="Login Background"
                className="login-background"/>
            <div className="login-box">
                <LazyLoadImage
                    src={webSiteLogo}
                    alt="Logo"
                    className="login-logo"
                />
                <div className="login-box-body">
                    <h4 className="login-box-msg">Admin Panel Login</h4>
                    <div className="login-box-form">
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                        <div className="login-button" onClick={handleLogin}>
                            Login
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );

};

export default Login;
