import React from 'react';
import Head from 'next/head';

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
                    <h1>Privacy Policy</h1>
                </div>
            </div>
            <div className="bg-white">
                <div className="container privacy-policy">
                    <div className="row">
                        <div className="col-12">
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet assumenda ducimus possimus
                                quibusdam ratione totam vitae voluptatem. Aliquam asperiores cupiditate expedita labore odit
                                officiis quam tempora vitae. Consectetur, hic, sapiente.
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias debitis dolorem eaque
                                eveniet facilis, illo laborum minus quasi quis sed similique tempora unde ut velit vitae? Et
                                perspiciatis porro rerum?</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet assumenda ducimus possimus
                                quibusdam ratione totam vitae voluptatem. Aliquam asperiores cupiditate expedita labore odit
                                officiis quam tempora vitae. Consectetur, hic, sapiente.
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias debitis dolorem eaque
                                eveniet facilis, illo laborum minus quasi quis sed similique tempora unde ut velit vitae? Et
                                perspiciatis porro rerum?</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet assumenda ducimus possimus
                                quibusdam ratione totam vitae voluptatem. Aliquam asperiores cupiditate expedita labore odit
                                officiis quam tempora vitae. Consectetur, hic, sapiente.
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias debitis dolorem eaque
                                eveniet facilis, illo laborum minus quasi quis sed similique tempora unde ut velit vitae? Et
                                perspiciatis porro rerum?</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet assumenda ducimus possimus
                                quibusdam ratione totam vitae voluptatem. Aliquam asperiores cupiditate expedita labore odit
                                officiis quam tempora vitae. Consectetur, hic, sapiente.
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias debitis dolorem eaque
                                eveniet facilis, illo laborum minus quasi quis sed similique tempora unde ut velit vitae? Et
                                perspiciatis porro rerum?</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                                Amet assumenda ducimus possimus quibusdam ratione totam vitae voluptatem. Aliquam asperiores
                                cupiditate expedita labore odit officiis quam tempora vitae. Consectetur, hic, sapiente.
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias debitis dolorem eaque eveniet
                                facilis, illo laborum minus quasi quis sed similique tempora unde ut velit vitae? Et
                                perspiciatis porro rerum?</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet assumenda ducimus possimus
                                quibusdam ratione totam vitae voluptatem. Aliquam asperiores cupiditate expedita labore odit
                                officiis quam tempora vitae. Consectetur, hic, sapiente.
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias debitis dolorem eaque
                                eveniet facilis, illo laborum minus quasi quis sed similique tempora unde ut velit vitae? Et
                                perspiciatis porro rerum?</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                                Amet assumenda ducimus possimus quibusdam ratione totam vitae voluptatem. Aliquam asperiores
                                cupiditate expedita labore odit officiis quam tempora vitae. Consectetur, hic, sapiente.
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias debitis dolorem eaque eveniet
                                facilis, illo laborum minus quasi quis sed similique tempora unde ut velit vitae? Et
                                perspiciatis porro rerum?</p>
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
    const siteUrl = `${protocol}://${host}/privacy-policy`;
    const siteTitle = "Privacy Policy - Accon";
    const siteDescription = "Read the privacy policy for using our services at Accon.";
    const ogImage = `${protocol}://${host}/banner_service.jpg`;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;

    const structuredData = {
        "@context": "https://schema.org",
        "@type": "WebPage",
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
