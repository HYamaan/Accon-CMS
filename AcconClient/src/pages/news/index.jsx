import React from 'react';
import { recentPostJson } from "@/data/recentPostJson";
import RecentPostCard from "@/Components/Card/RecentPostCard";
import Head from 'next/head';
import axios from "axios";
import https from 'https';

const Index = ({ pageInformation, ogImage, siteUrl, structuredData }) => {
    return (
        <>
            <Head>
                <title>{pageInformation.metaTitle}</title>
                <meta name="description" content={pageInformation.metaDescription} />
                <meta property="og:title" content={pageInformation.metaTitle} />
                <meta property="og:description" content={pageInformation.metaDescription} />
                <meta property="og:image" content={ogImage} />
                <meta property="og:url" content={siteUrl} />
                <meta name="twitter:card" content="summary_large_image" />
                <meta name="twitter:title" content={pageInformation.metaTitle} />
                <meta name="twitter:description" content={pageInformation.metaDescription} />
                <meta name="twitter:image" content={ogImage} />
                <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
            </Head>
            <div className="banner-slider" style={{ backgroundImage: "url(banner_service.jpg)" }}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>News</h1>
                </div>
            </div>
            <div className="testimonial-page">
                <div className="container">
                    <div className="row">
                        {pageInformation?.news?.map((item, index) => {
                            return (
                                <div key={index} className="col-md-4 col-sm-3">
                                    <RecentPostCard data={item} baseUrl="news" />
                                </div>
                            );
                        })}
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
    const siteUrl = `${protocol}://${host}/news`;
    const ogImage = `${siteUrl}/banner_service.jpg`;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;



    const axiosInstance = axios.create({
        httpsAgent: new https.Agent({
            rejectUnauthorized: false
        })
    });

    try {
        const getNews = await axiosInstance.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetNewsPage`);
        if (getNews.data.succeeded === false) {
            return {
                redirect: {
                    destination: '/404',
                    permanent: false
                }
            }
        } else {
            const newsPage = getNews.data.data;

            const structuredData = {
                "@context": "https://schema.org",
                "@type": "WebSite",
                "url": siteUrl,
                "name": newsPage.metaTitle,
                "description": newsPage.metaDescription,
                "publisher": {
                    "@type": "Organization",
                    "name": companyName,
                    "url": siteUrl,
                    "logo": {
                        "@type": "ImageObject",
                        "url": `${siteUrl}/logo.png`
                    }
                }
            };

            return {
                props: {
                    ogImage,
                    siteUrl,
                    structuredData,
                    pageInformation:newsPage
                }
            };

        }
    }catch (e){
        return {
            redirect: {
                destination: '/404',
                permanent: false
            }
        }
    }

};
