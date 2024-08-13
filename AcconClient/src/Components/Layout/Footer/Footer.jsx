import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import Link from "next/link";
import {recentPostJson} from "@/data/recentPostJson";

const Footer = ({data}) => {
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
                                    effect="blur"
                                    alt={data?.adressIcon}
                                    src={`/${data?.adressIcon}`}
                                />
                            </li>
                            <li>
                                <h4>Address</h4>
                                <p dangerouslySetInnerHTML={{__html: data?.address.replace(/\n/g, '<br />')}}/>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className="col-md-4 col-sm-4">
                    <div className="footer-contact-item">
                        <ul>
                            <li>
                                <LazyLoadImage
                                    effect="blur"
                                    alt={data?.phoneIcon}
                                    src={`/${data?.phoneIcon}`}
                                />
                            </li>
                            <li>
                                <h4>Call Us</h4>
                                <p dangerouslySetInnerHTML={{__html: data?.phone.replace(/\n/g, '<br />')}}/>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className="col-md-4 col-sm-4">
                    <div className="footer-contact-item">
                        <ul>
                            <li>
                                <LazyLoadImage
                                    effect="blur"
                                    alt="footer_working_hour_icon.png"
                                    src={`/${data?.workingHoursIcon}`}
                                />
                            </li>
                            <li>
                                <h4>Working Hours</h4>
                                <p dangerouslySetInnerHTML={{__html: data?.workingHours.replace(/\n/g, '<br />')}}/>
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
                        <p dangerouslySetInnerHTML={{__html: data?.aboutUs.replace(/\n/g, '<br />')}}/>
                    </div>
                    <div className="col-sm-6 col-md-3 col-lg-3 footer-col">
                        {/*<h3>Popular News</h3>*/}
                        {/*{*/}
                        {/*    popularProject.map((item, index) => (*/}
                        {/*        <div className="news-item" key={index}>*/}
                        {/*            <div className="news-title">*/}
                        {/*                <Link href={`news/${item.url}`} target="_blank">*/}
                        {/*                    {item.title}*/}
                        {/*                </Link>*/}
                        {/*            </div>*/}
                        {/*        </div>*/}
                        {/*    ))*/}
                        {/*}*/}
                    </div>
                    <div className="col-sm-6 col-md-3 col-lg-3 footer-col">
                        <h3>Latest News</h3>
                        {data?.latestNews.length > 0 &&
                            data?.latestNews.map((item, index) => (
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
                                <Link href="/terms-and-conditions">
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
                        <p dangerouslySetInnerHTML={{__html: data?.copyRight}}></p>
                    </div>
                </div>
            </div>
        </div>
    </>
};

export default Footer;
