import React, { useEffect } from 'react';
import { LazyLoadImage } from "react-lazy-load-image-component";
import { accordionData } from "@/data/faqJson";
import faq from "@/pages/faq";

const Faq = ({faqData}) => {
    useEffect(() => {
        import('bootstrap/dist/js/bootstrap.bundle.min.js');
    }, []);


    console.log("faqData", faqData);
    if(faqData === undefined || faqData === null){
        return (
            <div className="faq-section">
                <div className="container faq">
                    <div className="row">
                        <div className="col-md-6 col-sm-12 faq-img">
                            <LazyLoadImage
                             src={`/${faqData.mainPhoto}`}
                                alt={faqData.mainPhoto}
                                effect="blur"
                            />
                        </div>
                        <div className="col-md-6 col-sm-12">
                            <div className="faq-gallery">
                                <h3>{faqData.title}</h3>
                                <h4 className="sub">
                                    {faqData.subTitle}
                                </h4>
                                <div className="accordion accordion-flush" id="accordionFaq">
                                    {faqData?.faqs.map((item, index) => {
                                        const headingId = `flush-heading-${index}`;
                                        const collapseId = `flush-collapse-${index}`;
                                        return (
                                            <div className="accordion-item" key={index}>
                                                <h2 className="accordion-header" id={headingId}>
                                                    <button className="accordion-button collapsed" type="button"
                                                            data-bs-toggle="collapse" data-bs-target={`#${collapseId}`}
                                                            aria-expanded="false" aria-controls={collapseId}>
                                                        {item.title}
                                                    </button>
                                                </h2>
                                                <div id={collapseId} className="accordion-collapse collapse"
                                                     aria-labelledby={headingId} data-bs-parent="#accordionFaq">
                                                    <div className="accordion-body">
                                                        {item.content}
                                                    </div>
                                                </div>
                                            </div>
                                        );
                                    })}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }else{
        return (
            <div className="faq-section">
                <div className="container faq">
                    <div className="row">
                        <div className="col-md-6 col-sm-12 faq-img">
                            <LazyLoadImage
                                src={`/${faqData.backgroundImage}`}
                                alt={faqData.backgroundImage}
                                effect="blur"
                            />
                        </div>
                        <div className="col-md-6 col-sm-12">
                            <div className="faq-gallery">
                                <h3>{faqData.title}</h3>
                                <h4 className="sub">
                                    {faqData.subTitle}
                                </h4>
                                <div className="accordion accordion-flush" id="accordionFaq">
                                    {faqData.faqs?.map((item, index) => {
                                        const headingId = `flush-heading-${index}`;
                                        const collapseId = `flush-collapse-${index}`;
                                        return (
                                            <div className="accordion-item" key={index}>
                                                <h2 className="accordion-header" id={headingId}>
                                                    <button className="accordion-button collapsed" type="button"
                                                            data-bs-toggle="collapse" data-bs-target={`#${collapseId}`}
                                                            aria-expanded="false" aria-controls={collapseId}>
                                                        {item.title}
                                                    </button>
                                                </h2>
                                                <div id={collapseId} className="accordion-collapse collapse"
                                                     aria-labelledby={headingId} data-bs-parent="#accordionFaq">
                                                    <div className="accordion-body"
                                                         dangerouslySetInnerHTML={{__html: item.content}}>
                                                    </div>
                                                </div>
                                            </div>
                                        );
                                    })}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
};

export default Faq;
