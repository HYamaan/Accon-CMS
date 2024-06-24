import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";

const ChooseUs = () => {
    return <section className="chooseUs-section">
        <div className="container choose">
            <div className="headline">
                <h2>WHY CHOOSE US</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate</p>
            </div>
        </div>
        <div className="choose-item-row">
            <div className="col-md-6">
                <LazyLoadImage
                    alt="why-choose-main-photo"
                    src={"why-choose-main-photo.jpg"}
                    className="choose-left"
                />
            </div>
            <div className="col-md-6 choose-right">
                <LazyLoadImage
                    alt="why-choose-item-bg"
                    src={"why-choose-item-bg.jpg"}
                    className="choose-right-bg"
                />
                <div className="choose-item">
                    <ul>
                        <li>
                            <div className="choose-icon">
                                <LazyLoadImage
                                    alt="why-choose-1"
                                    src={"why-choose-1.png"}
                                />
                            </div>
                            <div className="choose-text">
                                <h3>Brute altera causae ne sed cum no</h3>
                                <p>Lorem ipsum dolor sit amet, an labores explicari qui, eu nostrum copiosae argumentum
                                    has.
                                    Latine propriae quo no, unum ridens expetenda id sit, at usu eius eligendi
                                    singulis.Sea
                                    ocurreret principes ne.</p>
                            </div>
                        </li>
                        <li>
                            <div className="choose-icon">
                                <LazyLoadImage
                                    alt="why-choose-2"
                                    src={"why-choose-2.png"}
                                />
                            </div>
                            <div className="choose-text">
                                <h3>Vix tale noluisse voluptua ad ne</h3>
                                <p>Lorem ipsum dolor sit amet, an labores explicari qui, eu nostrum copiosae argumentum
                                    has.
                                    Latine propriae quo no, unum ridens expetenda id sit, at usu eius eligendi
                                    singulis.Sea
                                    ocurreret principes ne.</p>
                            </div>
                        </li>
                        <li>
                            <div className="choose-icon">
                                <LazyLoadImage
                                    alt="why-choose-3"
                                    src={"why-choose-3.png"}
                                />
                            </div>
                            <div className="choose-text">
                                <h3>Vix tale noluisse voluptua ad ne</h3>
                                <p>Lorem ipsum dolor sit amet, an labores explicari qui, eu nostrum copiosae argumentum
                                    has.
                                    Latine propriae quo no, unum ridens expetenda id sit, at usu eius eligendi
                                    singulis.Sea
                                    ocurreret principes ne.</p>
                            </div>
                        </li>
                        <li>
                            <div className="choose-icon">
                                <LazyLoadImage
                                    alt="why-choose-4"
                                    src={"why-choose-4.png"}
                                />
                            </div>
                            <div className="choose-text">
                                <h3>Mei ut errem legimus, periculis eos</h3>
                                <p>Lorem ipsum dolor sit amet, an labores explicari qui, eu nostrum copiosae argumentum
                                    has.
                                    Latine propriae quo no, unum ridens expetenda id sit, at usu eius eligendi
                                    singulis.Sea
                                    ocurreret principes ne.</p>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
};

export default ChooseUs;
