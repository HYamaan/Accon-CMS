import React from 'react';
import Head from 'next/head';
import { LazyLoadImage } from "react-lazy-load-image-component";
import { FaHeart, FaStar } from "react-icons/fa";
import axios from "axios";
import https from 'https';

const Index = ({ pageInformation, ogImage, siteUrl, structuredData }) => {
    const siteTitle = pageInformation.metaTitle;

    return (
        <>
            <Head>
                <title>{siteTitle}</title>
                <meta name="description" content={pageInformation.metaDescription} />
                <meta name="keywords" content={pageInformation.metaKeywords} />
                <meta property="og:title" content={pageInformation.metaTitle} />
                <meta property="og:description" content={pageInformation.metaDescription} />
                <meta property="og:image" content={ogImage} />
                <meta property="og:url" content={siteUrl} />
                <meta name="twitter:card" content="summary_large_image" />
                <meta name="twitter:title" content={siteTitle} />
                <meta name="twitter:description" content={pageInformation.metaDescription} />
                <meta name="twitter:image" content={ogImage} />
                <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
            </Head>
            <div className="banner-slider" style={{ backgroundImage: "url(banner_service.jpg)" }}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>{pageInformation.title}</h1>
                </div>
            </div>
            <div className="bg-white">
                <div className="container pt-5 pb-5">
                    <div className="row">
                        <div className="col-md-12">
                            <LazyLoadImage
                                src={`/${pageInformation.photo}`}
                                alt={pageInformation.photo}
                                effect="blur"
                                width="100%"
                                className={"about-main-image"}
                            />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-md-12">
                            <div dangerouslySetInnerHTML={{ __html: pageInformation.content }} />
                        </div>
                    </div>
                </div>
            </div>
            <div className="container mb-5 pb-5">
                <div className="row">
                    <div className="col-md-6 col-sm-6">
                        <div className="about-mission">
                            <div className="mission-icon">
                                <FaStar />
                            </div>
                            <h3>{pageInformation.missionTitle}</h3>
                            {pageInformation.missionContent}
                        </div>
                    </div>
                    <div className="col-md-6 col-sm-6">
                        <div className="about-mission">
                            <div className="mission-icon">
                                <FaHeart />
                            </div>
                            <h3>{pageInformation.visionTitle}</h3>
                            <p>{pageInformation.visionContent}</p>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default Index;

export const getServerSideProps = async ({ req }) => {
    const protocol = req.headers['x-forwarded-proto'] || 'http';
    const host = req.headers.host;
    const siteUrl = `${protocol}://${host}/about`;
    const ogImage = `${protocol}://${host}/about_photo.jpg`;

    const axiosInstance = axios.create({
        httpsAgent: new https.Agent({
            rejectUnauthorized: false
        })
    });

    try {
        const getAboutPage = await axiosInstance.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetAboutPage`);
        if (getAboutPage.data.succeeded === false) {
            return {
                redirect: {
                    destination: '/404',
                    permanent: false
                }
            }
        } else {
            const aboutPage = getAboutPage.data.data;

            const structuredData = {
                "@context": "https://schema.org",
                "@type": "Organization",
                "url": siteUrl,
                "name": aboutPage.metaTitle,
                "description": aboutPage.metaDescription,
                "logo": {
                    "@type": "ImageObject",
                    "url": `${protocol}://${host}/logo.png`
                }
            };

            return {
                props: {
                    ogImage,
                    siteUrl,
                    structuredData,
                    pageInformation: aboutPage
                }
            };
        }
    } catch (error) {
        console.error('Error fetching about page:', error);
        return {
            redirect: {
                destination: '/500',
                permanent: false
            }
        };
    }
};
