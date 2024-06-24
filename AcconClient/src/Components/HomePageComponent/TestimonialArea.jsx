import React from 'react';
import SliderTestimonialArea from "@/Components/Slider/SliderTestimonialArea";
import {testimonialJson} from "@/data/testimonialJson";
const TestimonialArea = () => {



    return <>
        <div className="testimonial-area"
        style={{backgroundImage: "url(testimonial-main-photo.jpg)"}}
        >
            <div className="bg-testimonial"> </div>
                <div className="container">
                    <div className="row">
                        <div className="testimonial-headline">
                            <h2>WHAT OUR CLIENTS SAY</h2>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate</p>
                        </div>
                        <div className="col-md-12">
                     <SliderTestimonialArea data={testimonialJson}/>
                        </div>
                    </div>
                </div>

        </div>
    </>
};

export default TestimonialArea;
