import React, {useEffect, useState} from 'react';
import {Table, Thead, Tbody, Tr, Th, Td} from 'react-super-responsive-table';
import 'react-super-responsive-table/dist/SuperResponsiveTableStyle.css';
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {useMediaQuery} from "react-responsive";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

const ViewService = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });


    const [services, setServices] = useState([]);
    const [tempServices, setTempServices] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Service/GetAllService`);
                if (response.data.succeeded) {
                    setServices(response.data.data.services);
                    const filteredKeys = Object.keys(response.data.data.services[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching services:', error);
            } finally {
                setLoading(false);
            }

        };

        fetchSliders();
    }, []);

    const searchChangeHandler = (value) => {
        if (tempServices.length === 0) {
            setTempServices(services);
        }

        if (value.length > 0) {
            const searchSliders = services.filter(service =>
                service.heading.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(service =>
                service.heading.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(service =>
                service.heading.toLowerCase() !== value.toLowerCase()
            );

            setServices([...exactMatch, ...otherMatches]);
        } else {
            setServices(tempServices);
        }
    };
    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/Service/DeleteService?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("Slider deleted successfully")
                setServices(services.filter(service => service.id !== id));
            }
        } catch (error) {
            console.error('Error deleting slider:', error);
        }
    }
    const editClickHandler = (id) => {
        router.push(`/admin/service/edit/add?Id=${id}`);
    }

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View Service</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={()=>router.push("service/add")}>
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
                                    <option value="Heading">Heading</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text"
                                   placeholder="Search"
                                   onChange={(event)=>searchChangeHandler(event.target.value)}
                            />
                        </div>
                    </div>
                    <Table>
                        <Thead>
                            <Tr>
                                <Th>SL</Th>
                                <Th>Photo</Th>
                                <Th>Banner</Th>
                                <Th>Heading</Th>
                                <Th>Action</Th>
                            </Tr>
                        </Thead>
                        <Tbody>
                            {services.map((service, index) => (
                                <Tr key={service.id}>
                                    <Td>{index + 1}</Td>
                                    <Td>
                                        <LazyLoadImage
                                            src={`/${service.photo}`}
                                            alt="Service Photo"
                                            className="slider-table-image"
                                        />
                                    </Td>
                                    <Td>
                                        <LazyLoadImage
                                            src={`/${service.banner}`}
                                            alt="Service Banner"
                                            className="slider-table-banner-image"
                                        />
                                    </Td>
                                    <Td>{service.heading}</Td>
                                    <Td>
                                        <button className="btn btn-warning me-2" onClick={() =>editClickHandler(service.id)}>Edit</button>
                                        <button className="btn btn-danger" onClick={() => deleteClickHandler(service.id)}>Delete</button>
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

export default ViewService;
