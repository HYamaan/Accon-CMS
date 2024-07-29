import React from 'react';
import Card from "@/Components/Card/Card";
import { cardJson } from "@/data/service";

const Services = ({services}) => {
    return (
        <section className="services-section">
            <div className="container services">
                <div className="headline">
                    <h2>{services.title}</h2>
                    <p>{services.subTitle}</p>
                </div>
                <div className="row">
                    {services?.services?.map((item, index) =>
                        <div key={index} className="col-md-4 col-sm-6 col-xs-12 clear-three">
                            <Card data={item} baseUrl={"portfolio"} />
                        </div>
                    )}
                </div>
            </div>
        </section>
    );
};

export default Services;
