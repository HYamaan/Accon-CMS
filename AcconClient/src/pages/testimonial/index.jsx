import React from 'react';
import Head from 'next/head';
import SliderTestimonialArea from "@/Components/Slider/SliderTestimonialArea";
import { testimonialJson } from "@/data/testimonialJson";

const Index = ({ siteTitle, siteDescription, ogImage, siteUrl, structuredData }) => {
    return (
        <>
            <Head>
                <title>{siteTitle}</title>
                <meta name="description" content={siteDescription} />
                <meta property="og:title" content={siteTitle} />
                <meta property="og:description" content={siteDescription} />
                <meta property="og:image" content={ogImage} />
                <meta property="og:url" content={siteUrl} />
                <meta name="twitter:card" content="summary_large_image" />
                <meta name="twitter:title" content={siteTitle} />
                <meta name="twitter:description" content={siteDescription} />
                <meta name="twitter:image" content={ogImage} />
                <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
            </Head>
            <div className="banner-slider" style={{ backgroundImage: "url(banner_service.jpg)" }}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>TESTIMONIAL</h1>
                </div>
            </div>
            <div className="bg-white py-2 testimonial-page">
                <div className="container mb-5">
                    <div className="col-md-12">
                        <SliderTestimonialArea data={testimonialJson} />
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
    const siteUrl = `${protocol}://${host}/testimonial`;
    const siteTitle = "Testimonial - Accon";
    const siteDescription = "Read what our clients have to say about our services. Discover testimonials from satisfied customers.";
    const ogImage = `${siteUrl}/banner_service.jpg`;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;

    const structuredData = {
        "@context": "https://schema.org",
        "@type": "WebSite",
        "url": siteUrl,
        "name": siteTitle,
        "description": siteDescription,
        "publisher": {
            "@type": "Organization",
            "name": companyName,
            "url": siteUrl,
            "logo": {
                "@type": "ImageObject",
                "url": `${protocol}://${host}/logo.png`
            }
        }
    };

    return {
        props: {
            siteTitle,
            siteDescription,
            ogImage,
            siteUrl,
            structuredData
        }
    };
};
