import React from 'react';
import {recentPostJson} from "@/data/recentPostJson";
import RecentPostCard from "@/Components/Card/RecentPostCard";
import Head from "next/head";

const News = ({siteDescription,siteTitle,siteUrl,structuredData}) => {
    return <>
        <Head>
            <title>{siteTitle}</title>
            <meta name="description" content={siteDescription} />
            <meta property="og:title" content={siteTitle} />
            <meta property="og:description" content={siteDescription} />
            <meta property="og:url" content={siteUrl} />
            <meta name="twitter:card" content="summary_large_image" />
            <meta name="twitter:title" content={siteTitle} />
            <meta name="twitter:description" content={siteDescription} />
            <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
        </Head>
        <div className="banner-slider" style={{
            backgroundImage: "url(banner_service.jpg)",
        }}>
            <div className="bg"></div>
            <div className="banner-text">
                <h1>News</h1>
            </div>
        </div>
        <div className="testimonial-page">
            <div className="container">
                <div className="row">
                    {recentPostJson.map((item, index) => {
                        return <div key={index} className="col-md-4 col-sm-3">
                            <RecentPostCard data={item}/>
                        </div>
                    })}
                </div>
            </div>
        </div>
    </>
};

export default News;
