/*JavaScript for cars page*/ 

/* adding location and filter them implementation*/
const menu = [
    {
      id: 1,
      name: "Honda Civic",
      category: "compact",
      year: 2017,
      img: "images/car5.jpg",
      desc: `I'm baby woke mlkshk wolf bitters live-edge blue bottle, hammock freegan copper mug whatever cold-pressed `,
      alt: "Car logo not available",
    },
    {
      id: 2,
      name: "Mercedes E Coupe",
      category: "coupe",
      year: 2018,
      img: "images/car2.jpg",
      desc: `vaporware iPhone mumblecore selvage raw denim slow-carb leggings gochujang helvetica man braid jianbing. Marfa thundercats `,
      alt: "Car logo not available",
    },
    {
      id: 3,
      name: "Skoda Superb III Combi",
      category: "break",
      year: 2019,
      img: "images/car3.jpg",
      desc: `ombucha chillwave fanny pack 3 wolf moon street art photo booth before they sold out organic viral.`,
      alt: "Car logo not available",
    },
    {
      id: 4,
      name: "Audi A5 S line",
      category: "coupe",
      year: 2014,
      img: "images/car4.jpg",
      desc: `Shabby chic keffiyeh neutra snackwave pork belly shoreditch. Prism austin mlkshk truffaut, `,
      alt: "Car logo not available",
    },
    {
      id: 5,
      name: "Audi A6 Variant",
      category: "break",
      year: 2018,
      img: "images/car6.jpg",
      desc: `franzen vegan pabst bicycle rights kickstarter pinterest meditation farm-to-table 90's pop-up `,
      alt: "Car logo not available",
    },

  ];
  
  const sectionCenter = document.querySelector(".section-center");
  const filterBtns = document.querySelectorAll(".filter-btn");

  window.addEventListener("DOMContentLoaded", function () {
   displayMenuItems(menu);
  });
  //filter items
  filterBtns.forEach(function(btn){
    btn.addEventListener("click", function (e){
    const category = e.currentTarget.dataset.id;
    const menuCategory = menu.filter(function (menuItems){
     
    if(menuItems.category === category){
      return menuItems;
    }
    });
    if(category === "all"){
      displayMenuItems(menu);
    }
    else{
      displayMenuItems(menuCategory);
    }
    });
  });
  //adding location
  function displayMenuItems(menuItems){
    let displayMenu = menuItems.map(function (item) {
      // console.log(item);
  
      return `<article class="menu-item">
      <a class="btn_image"href="assurancePage.html">
        <img src=${item.img} alt="${item.alt}" class="photo"/>
      </a>      
        <div class="item-info">
              <header>
                <h4>${item.name}</h4>
                <h4 class="nr-cars">Year: ${item.year}</h4>
              </header>
              <p class="description">
                ${item.desc}
              </p>
            </div>
          </article>`;
    });
    displayMenu = displayMenu.join("");
    console.log(displayMenu);//for verify
  
    sectionCenter.innerHTML = displayMenu;
  };
  /* end of adding and filter them location */