import React from 'react';
import SliderTestimonialArea from "@/Components/Slider/SliderTestimonialArea";
import {testimonialJson} from "@/data/testimonialJson";
const TestimonialArea = ({testimonials}) => {



    return <>
        <div className="testimonial-area"
        style={{backgroundImage: "url(testimonial-main-photo.jpg)"}}
        >
            <div className="bg-testimonial"> </div>
                <div className="container">
                    <div className="row">
                        <div className="testimonial-headline">
                            <h2>{testimonials.title}</h2>
                            <p>{testimonials.subTitle}</p>
                        </div>
                        <div className="col-md-12">
                     <SliderTestimonialArea data={testimonials.testimonials}/>
                        </div>
                    </div>
                </div>

        </div>
    </>
};

export default TestimonialArea;
