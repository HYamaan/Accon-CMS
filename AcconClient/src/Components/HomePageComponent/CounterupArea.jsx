import React from 'react';
import CountUp from 'react-countup';
import { useInView } from 'react-intersection-observer';

const CounterupArea = ({counterSection}) => {
    const [ref, inView] = useInView({
        threshold: 0.1,
        triggerOnce: true
    });

    return (
            <div ref={ref} className="counterup-area" style={{backgroundImage: "url(counter_bg.jpg)"}}>
                <div className="bg-counterup"></div>
                <div className="container">
                    <div className="row">
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={counterSection.text1Value} duration={2.75}/>}
                                </h2>
                                <h4>{counterSection.text1}</h4>
                            </div>
                        </div>
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={counterSection.text2Value} duration={2.75}/>}
                                </h2>
                                <h4>{counterSection.text2}</h4>
                            </div>
                        </div>
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={counterSection.text3Value} duration={2.75}/>}
                                </h2>
                                <h4>{counterSection.text3}</h4>
                            </div>
                        </div>
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item achieved">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={counterSection.text4Value} duration={2.75}/>}
                                </h2>
                                <h4>{counterSection.text4}</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    );
};

export default CounterupArea;
