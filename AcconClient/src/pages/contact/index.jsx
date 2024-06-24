import React from 'react';
import Head from 'next/head';
import {useFormik} from "formik";
import {contactSchema} from "@/schema/contact";
import axios from "axios";
import {toast} from "react-toastify";

const Index = ({siteTitle, siteDescription, ogImage, siteUrl, structuredData}) => {
    const onSubmit = async (values, actions) => {
        try {
            const response = await axios.post('/api/sendMail/mail', values);
            if (response.status === 200) {
                toast.success("Your message has been sent successfully.");
                actions.resetForm();
            } else {
                toast.error("An error occurred while sending your message. Please try again later.");
            }
        } catch (error) {
            toast.error("An error occurred while sending your message. Please try again later.");
            console.error("Error: ", error.response ? error.response.data : error.message);
        }
    }

    const ContactFormik = useFormik({
        initialValues: {
            name: "",
            email: "",
            phone: "",
            message: "",
        },
        onSubmit,
        validationSchema: contactSchema,
    });

    const formFields = [
        {
            id: 1,
            name: "name",
            type: "text",
            placeholder: "Name",
            title: "Name",
        },
        {
            id: 2,
            name: "email",
            type: "email",
            placeholder: "Your Email",
            title: "Email Address",
        },
        {
            id: 3,
            name: "phone",
            type: "text",
            placeholder: "Your Phone",
            title: "Phone Number",
        },
        {
            id: 4,
            name: "message",
            type: "textarea",
            placeholder: "Message",
            title: "Message",
        }
    ];

    return (
        <>
            <Head>
                <title>{siteTitle}</title>
                <meta name="description" content={siteDescription}/>
                <meta property="og:title" content={siteTitle}/>
                <meta property="og:description" content={siteDescription}/>
                <meta property="og:image" content={ogImage}/>
                <meta property="og:url" content={siteUrl}/>
                <meta name="twitter:card" content="summary_large_image"/>
                <meta name="twitter:title" content={siteTitle}/>
                <meta name="twitter:description" content={siteDescription}/>
                <meta name="twitter:image" content={ogImage}/>
                <script type="application/ld+json" dangerouslySetInnerHTML={{__html: JSON.stringify(structuredData)}}/>
            </Head>
            <div className="banner-slider" style={{backgroundImage: "url(banner_service.jpg)"}}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>Contact</h1>
                </div>
            </div>
            <div className="contact-area">
                <div className="container">
                    <div className="row">
                        <div className="col-md-6">
                            <h4>Contact us through the following form:</h4>
                            <form onSubmit={ContactFormik.handleSubmit} className="contact-form">
                                {formFields.map((field) => (
                                    <div key={field.id} className="form-group">
                                        <label htmlFor={field.name}>{field.title}</label>
                                        {field.type === 'textarea' ? (
                                            <textarea
                                                id={field.name}
                                                name={field.name}
                                                placeholder={field.placeholder}
                                                value={ContactFormik.values[field.name]}
                                                onChange={ContactFormik.handleChange}
                                                onBlur={ContactFormik.handleBlur}
                                                className={`form-control ${
                                                    ContactFormik.touched[field.name] &&
                                                    ContactFormik.errors[field.name]
                                                        ? 'is-invalid'
                                                        : ''
                                                }`}
                                            />
                                        ) : (
                                            <input
                                                type={field.type}
                                                id={field.name}
                                                name={field.name}
                                                placeholder={field.placeholder}
                                                value={ContactFormik.values[field.name]}
                                                onChange={ContactFormik.handleChange}
                                                onBlur={ContactFormik.handleBlur}
                                                className={`form-control ${
                                                    ContactFormik.touched[field.name] &&
                                                    ContactFormik.errors[field.name]
                                                        ? 'is-invalid'
                                                        : ''
                                                }`}
                                            />
                                        )}
                                        {ContactFormik.touched[field.name] &&
                                        ContactFormik.errors[field.name] ? (
                                            <div className="invalid-feedback">
                                                {ContactFormik.errors[field.name]}
                                            </div>
                                        ) : null}
                                    </div>
                                ))}
                                <button type="submit" className="secondary-button mt-3 w-25">
                                    Submit
                                </button>
                            </form>
                        </div>
                        <div className="col-md-6">
                            <h4>Find Us on Map:</h4>
                            <div className="map-area">
                                <iframe
                                    src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d6019.278848763908!2d28.775219911330108!3d41.03314397257238!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14caa5002651df87%3A0xc08708bf183d61a8!2sZaim%20%C3%BCniv!5e0!3m2!1str!2str!4v1718908958370!5m2!1str!2str"
                                    width="800"
                                    height="625"
                                    style={{border: 0}}
                                    allowFullScreen=""
                                    loading="lazy"
                                    referrerPolicy="no-referrer-when-downgrade"
                                ></iframe>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default Index;

export const getServerSideProps = async ({req}) => {
    const protocol = req.headers['x-forwarded-proto'] || 'http';
    const host = req.headers.host;
    const siteUrl = `${protocol}://${host}/contact`;
    const siteTitle = "Contact Us - Accon";
    const siteDescription = "Get in touch with Accon. We're here to help with any questions or concerns you may have.";
    const ogImage = `${protocol}://${host}/contact_photo.jpg`;
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
