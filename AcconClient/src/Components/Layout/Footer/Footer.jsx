import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import Link from "next/link";
import {recentPostJson} from "@/data/recentPostJson";

const Footer = () => {
    const [popularProject, setPopularProject] = useState([]);
    const [latestProject, setLatestProject] = useState([]);

    useEffect(() => {
        const popularProject = recentPostJson.filter(item => item.popular);
        const latestProject = recentPostJson.sort((a, b) => new Date(b.date) - new Date(a.date)).slice(0, 3);
        setPopularProject(popularProject);
        setLatestProject(latestProject);
    }, []);

    return <>
        <div className="footer-contact-area">
        <div className="container">
            <div className="row">
                <div className="col-md-4 col-sm-4">
                    <div className="footer-contact-item">
                        <ul>
                            <li>
                                <LazyLoadImage
                                    alt="footer_address_icon.png"
                                    src={"/footer_address_icon.png"}
                                />
                            </li>
                            <li>
                                <h4>Address</h4>
                                <p>
                                    Lane A21, ABC Steet,
                                </p>
                                <p>
                                    NewYork, USA.
                                </p>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className="col-md-4 col-sm-4">
                    <div className="footer-contact-item">
                        <ul>
                            <li>
                                <LazyLoadImage
                                    alt="footer_phone_icon.png"
                                    src={"/footer_phone_icon.png"}
                                />
                            </li>
                            <li>
                                <h4>Call Us</h4>
                                <p>
                                    111-222-3333
                                </p>
                                <p>111-222-4444</p>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className="col-md-4 col-sm-4">
                    <div className="footer-contact-item">
                        <ul>
                            <li>
                                <LazyLoadImage
                                    alt="footer_working_hour_icon.png"
                                    src={"/footer_working_hour_icon.png"}
                                />
                            </li>
                            <li>
                                <h4>Working Hours</h4>
                                <p>
                                    Monday-Friday (9:00 AM - 5:00 PM)
                                </p>
                                <p>Saturday and Sunday: Off</p>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <div className="footer-main">
            <div className="container">
                <div className="row">
                    <div className="col-sm-6 col-md-3 col-lg-3 footer-col ">
                        <h3>About</h3>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. A aspernatur culpa cumque, dolores
                            eligendi facilis fugit libero quibusdam vitae. Ab alias at iure libero minima molestiae
                            optio, provident sapiente voluptate?</p>
                    </div>
                    <div className="col-sm-6 col-md-3 col-lg-3 footer-col">
                        <h3>Latest News</h3>
                        {
                            latestProject.map((item, index) => (
                                <div className="news-item" key={index}>
                                    <div className="news-title">
                                        <Link href={`news/${item.url}`} target="_blank">
                                            {item.title}
                                        </Link>
                                    </div>
                                </div>
                            ))
                        }
                    </div>
                    <div className="col-sm-6 col-md-3 col-lg-3 footer-col">
                        <h3>Popular News</h3>
                        {
                            popularProject.map((item, index) => (
                                <div className="news-item" key={index}>
                                    <div className="news-title">
                                        <Link href={`news/${item.url}`} target="_blank">
                                            {item.title}
                                        </Link>
                                    </div>
                                </div>
                            ))
                        }
                    </div>
                    <div className="col-sm-6 col-md-3 col-lg-3 footer-col">
                        <h3>Quick Links</h3>
                        <div className="news-item">
                            <div className="news-title">
                                <Link href="/">
                                    Home
                                </Link>
                            </div>
                        </div>
                        <div className="news-item">
                            <div className="news-title">
                                <Link href="/terms-and-conditions" >
                                    Terms and Conditions
                                </Link>
                            </div>
                        </div>
                        <div className="news-item">
                            <div className="news-title">
                                <Link href="/privacy">
                                    Privacy Policy
                                </Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div className="footer-copyright">
            <div className="container">
                <div className="row">
                    <div className="col-md-12 copyright-text">
                      <p>
                          &#169; Copyright 2024. All Rights Reserved.
                      </p>
                    </div>
                </div>
            </div>
        </div>
    </>
};

export default Footer;
