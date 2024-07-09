import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";
import {VisibilityPlaceEnum} from "@/data/enum/VisibilityPlaceEnum";
import faq from "@/pages/faq";

const ViewFaq = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });
    const [faqs, setFaqs] = useState([]);
    const [tempFaqs, setTempFaqs] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);

    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Faq/GetAllFaq`);
                if (response.data.succeeded) {
                    setFaqs(response.data.data.faqs);
                    const filteredKeys = Object.keys(response.data.data.faqs[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching faqs:', error);
            } finally {
                setLoading(false);
            }
        };
        fetchSliders();
    }, []);
    const searchChangeHandler = (value) => {
        if (tempFaqs.length === 0) {
            setTempFaqs(faqs);
        }

        if (value.length > 0) {
            const searchSliders = faqs.filter(faq =>
                faq.title.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(faq =>
                faq.title.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(faq =>
                faq.title.toLowerCase() !== value.toLowerCase()
            );

            setFaqs([...exactMatch, ...otherMatches]);
        } else {
            setFaqs(tempFaqs);
        }
    };
    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/Faq/DeleteFaq?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("Slider deleted successfully")
                setFaqs(faqs.filter(faq => faq.id !== id));
            }
        } catch (error) {
            console.error('Error deleting slider:', error);
        }
    }
    const editClickHandler = (id) => {
        router.push(`/admin/faq/edit/add?id=${id}`);
    }

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View FAQ</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/faq/add")}
                >
                    <FaPlus />
                    <span>Add New</span>
                </div>
            </div>
            <div className="panel-box mt-3">
                <div className="panel-box-body">
                    <div className="slider-show-content">
                        <div className="slider-show-content__counter">
                            <span>Showing entries</span>
                            <select name="slider-show-entries" id="slider-show-entries">
                                <option value="10">10</option>
                                <option value="20">20</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                            </select>
                        </div>
                        {
                            isMobile && <div className="slider-show-content__sort">
                                <span>Sort:</span>
                                <select name="slider-show-entries" id="slider-show-entries">
                                    <option value="SL">SL</option>
                                    <option value="FaqTitle">FAQ Title</option>
                                    <option value="ShowOnHome">Show On Home ?</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text" placeholder="Search"
                                   onChange={(event)=>searchChangeHandler(event.target.value)}
                            />
                        </div>
                    </div>
                    <Table>
                        <Thead>
                            <Tr>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>SL</span>
                                        {!isMobile && <FaSortAmountDown />}
                                    </div>
                                </Th>
                                <Th className="table-body-col-header-45">
                                    <div className="slider-table-head">
                                        <span>FAQ Title</span>
                                        {!isMobile && <FaSortAmountDown />}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Show on Home ?</span>
                                        {!isMobile && <FaSortAmountDown />}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Action</span>
                                    </div>
                                </Th>
                            </Tr>
                        </Thead>
                        <Tbody>
                            {faqs.map((faq, index) => (
                                <Tr key={faq.id}>
                                    <Td>
                                        <div className="slider-table-body">
                                            {index + 1}
                                        </div>
                                    </Td>
                                    <Td>
                                        <div className="slider-table-body">
                                            {faq.title}
                                        </div>
                                    </Td>
                                    <Td>
                                        <div className="slider-table-body">
                                            {VisibilityPlaceEnum[faq.visiblePage]}
                                        </div>
                                    </Td>
                                    <Td>
                                        <div className="action-edit slider-table-body">
                                            <button className="btn btn-warning me-2" onClick={() => editClickHandler(faq.id)}>Edit</button>
                                            <button className="btn btn-danger" onClick={() => deleteClickHandler(faq.id)}>Delete</button>
                                        </div>
                                    </Td>
                                </Tr>
                            ))}
                        </Tbody>
                    </Table>

                    <div className="pagination-section">
                        <div className="pagination-information">
                            <span>Showing </span>
                            <span>1</span>
                            <span>to</span>
                            <span>2</span>
                            <span>of</span>
                            <span>2</span>
                            <span>entries</span>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </>
};

export default ViewFaq;
