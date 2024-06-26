import React, { useState } from 'react';

const CounterSettingsContent = () => {
    const [formData, setFormData] = useState({
        counter1Text: "",
        counter1Value: "",
        counter2Text: "",
        counter2Value: "",
        counter3Text: "",
        counter3Value: "",
        counter4Text: "",
        counter4Value: "",
        status: "true"
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevFormData => ({
            ...prevFormData,
            [name]: value
        }));
    };

    const handleSubmit = () => {
        console.log('Form Data:', formData);
        // API'ye gönderme işlemi
        // fetch('/api/submit', { method: 'POST', body: JSON.stringify(formData) })
    };

    return (
        <>
            <div className="tab-content">
                <h3 className="panel-website-icon">
                    Counter Settings
                </h3>
                <div className="container counter-settings-input-border">
                    <div className="row">
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter1 Text *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter1Text"
                                    value={formData.counter1Text}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter1 Value *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter1Value"
                                    value={formData.counter1Value}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter2 Text *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter2Text"
                                    value={formData.counter2Text}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter2 Value *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter2Value"
                                    value={formData.counter2Value}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter3 Text *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter3Text"
                                    value={formData.counter3Text}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter3 Value *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter3Value"
                                    value={formData.counter3Value}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter4 Text *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter4Text"
                                    value={formData.counter4Text}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                        <div className="panel-box-counter col-md-6">
                            <span className="col-md-3">Counter4 Value *</span>
                            <div className="col-md-9">
                                <input
                                    type="text"
                                    name="counter4Value"
                                    value={formData.counter4Value}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                    </div>
                </div>
                <div className="container">
                    <div className="row">
                        <div className="panel-box-select">
                            <span className="col-md-3">Status:</span>
                            <div className="col-md-9">
                                <select
                                    name="status"
                                    value={formData.status}
                                    onChange={handleChange}
                                >
                                    <option value="true">Show</option>
                                    <option value="false">Hidden</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="panel-box-select">
                            <div className="col-md-3"></div>
                            <div className="col-md-9 ps-2">
                                <button
                                    className="secondary-button panel-website-icon-show__button"
                                    onClick={handleSubmit}
                                >
                                    Submit
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default CounterSettingsContent;
