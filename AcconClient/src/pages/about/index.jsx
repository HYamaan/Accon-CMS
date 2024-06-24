import React from 'react';
import Head from 'next/head';
import { LazyLoadImage } from "react-lazy-load-image-component";
import { FaHeart, FaStar } from "react-icons/fa";

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
                    <h1>About</h1>
                </div>
            </div>
            <div className="bg-white">
                <div className="container pt-5 pb-5">
                    <div className="row">
                        <div className="col-md-12">
                            <LazyLoadImage
                                src={"about_photo.jpg"}
                                alt={"about_photo"}
                                effect="blur"
                                width="100%"
                            />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-md-12">
                            <h3 className="mt-3">About Us</h3>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae laudantium dignissimos
                                doloremque tempore fugiat error blanditiis voluptas aliquam fuga, molestiae. Corporis enim
                                iusto, in magnam, commodi minus officiis maxime neque. Lorem ipsum dolor sit amet,
                                consectetur adipisicing elit. Beatae laudantium dignissimos doloremque tempore fugiat error
                                blanditiis voluptas aliquam fuga, molestiae.
                            </p>
                            <p>
                                Corporis enim iusto, in magnam, commodi minus officiis maxime neque. Lorem ipsum dolor sit
                                amet, consectetur adipisicing elit. Beatae laudantium dignissimos doloremque tempore fugiat error
                                blanditiis voluptas aliquam fuga, molestiae. Corporis enim iusto, in magnam, commodi minus
                                officiis maxime neque.
                            </p>
                            <p>
                                Eu semper imperdiet duo, eos ut exerci sanctus impedit, sit ne legere maiorum gubergren.
                                Putent accusamus te qui, vero forensibus ei ius. His nostrud singulis forensibus te, in possim
                                gubergren his. Habemus officiis qui te, vix te meliore rationibus. No augue zril reformidans
                                est. Pro ex unum vidit, no est noster discere neglegentur, et dictas tamquam his.
                            </p>
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
                            <h3>Mission</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae laudantium dignissimos doloremque tempore fugiat error blanditiis voluptas aliquam fuga, molestiae. Corporis enim iusto, in magnam, commodi minus officiis maxime neque. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae laudantium dignissimos doloremque tempore fugiat error blanditiis voluptas aliquam fuga, molestiae. Corporis enim iusto, in magnam, commodi minus officiis maxime neque.</p>
                        </div>
                    </div>
                    <div className="col-md-6 col-sm-6">
                        <div className="about-mission">
                            <div className="mission-icon">
                                <FaHeart />
                            </div>
                            <h3>Vision</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae laudantium dignissimos doloremque tempore fugiat error blanditiis voluptas aliquam fuga, molestiae. Corporis enim iusto, in magnam, commodi minus officiis maxime neque. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae laudantium dignissimos doloremque tempore fugiat error blanditiis voluptas aliquam fuga, molestiae. Corporis enim iusto, in magnam, commodi minus officiis maxime neque.</p>
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
    const siteTitle = "About Us - Accon";
    const siteDescription = "Learn more about Accon, our mission, vision, and the team behind our success.";
    const ogImage = `${protocol}://${host}/about_photo.jpg`;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;

    const structuredData = {
        "@context": "https://schema.org",
        "@type": "Organization",
        "url": siteUrl,
        "name": siteTitle,
        "description": siteDescription,
        "logo": {
            "@type": "ImageObject",
            "url": `${protocol}://${host}/logo.png`
        },
        "contactPoint": {
            "@type": "ContactPoint",
            "telephone": "+1-800-555-5555",
            "contactType": "Customer Service"
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
