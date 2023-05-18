import React ,{useState} from 'react'
import '../assets/styles/book.css';

const Bookings = () => {

    const [currentTab,setCurrentTab] = useState('1');

    const tabs=[
        {
            id:1,
            tabtitle:'Tab1',
            title:'Title 1',
            content:'efr'
        },
        {
            id:2,
            tabtitle:'Tab1',
            title:'Title 1fweew',
            content:'efr'
        },
        {
            id:3,
            tabtitle:'Tab1',
            title:'Title 1',
            content:'efr'
        },
    ]

    const handleTabClick = (e) => {
        setCurrentTab(e.target.id)
    }
  return (
    <div className='bg-white'>
         <h1 className='text-center underline text-lg font-bold'>Bookings</h1>
    <div className='container11'> 
          
          <div className='tabs rounded-md border-r-black'> 
                  {tabs.map((tab,i) =>
                   <button 
                   key={i}
                   id={tab.id}
                   disabled ={currentTab === `${tab.id}`}
                   onClick={(handleTabClick)}
                  >
                    {tab.tabtitle}
                  </button>
                  )}
            </div>

            <div className='content'>
                {tabs.map((tab, i) =>
                            <div key={i}>
                             {currentTab === `${tab.id}` &&
                                <div >
                             <p> {tab.title} </p>

                             <p>{tab.content}</p>
                             
                              </div>
                             }
                    </div>
                )}
                
                </div> 

    </div>
    </div>
  )
}

export default Bookings