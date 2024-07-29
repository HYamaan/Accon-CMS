import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";

const ChooseUs = ({whyChooseUs}) => {
    return <section className="chooseUs-section">
        <div className="container choose">
            <div className="headline">
                <h2>{whyChooseUs.title}</h2>
                <p>{whyChooseUs.subTitle}</p>
            </div>
        </div>
        <div className="choose-item-row">
            <div className="col-md-6">
                <LazyLoadImage
                    alt={whyChooseUs.mainPhoto}
                    src={`/${whyChooseUs.mainPhoto}`}
                    className="choose-left"
                />
            </div>
            <div className="col-md-6 choose-right">
                <LazyLoadImage
                    alt={whyChooseUs.itemBackground}
                    src={`/${whyChooseUs.itemBackground}`}
                    className="choose-right-bg"
                />
                <div className="choose-item">
                    <ul>
                        {whyChooseUs?.whyChooseUsItems.map((item,index)=>(
                            <li key={item.Id}>
                            <div className="choose-icon">
                                <LazyLoadImage
                                    alt={item.photo}
                                    src={`/${item.photo}`}
                                />
                            </div>
                            <div className="choose-text">
                                <h3>{item.title}</h3>
                                <p>{item.content}</p>
                            </div>
                        </li>))}
                    </ul>
                </div>
            </div>
        </div>
    </section>
};

export default ChooseUs;
