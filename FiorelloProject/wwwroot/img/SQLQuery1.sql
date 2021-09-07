Use Fiorello 

INSERT INTO dbo.About(Title,[Text],[Image])
VALUES ('<h1>Suprise Your <span>Valentine!</span> Let us arrange a smile.</h1>','Where flowers are our inspiration to create lasting memories. Whatever the occasion...','h3-video-img.jpg')

INSERT INTO dbo.AboutLists(ListItem)
VALUES ('Hand picked just for you.'),('Unique flower arrangements'),('Best way to say you care.')

INSERT INTO dbo.Biography(Title,Link,[Type])
VALUES ('Twitter','https://twitter.com',2),
('Instagram','https://instagram.com',2),('Tumblr','https://Tumblr.com',2),
('Pinterest','https://pinterest.com',2),('logo.png',NULL,1)

INSERT INTO dbo.BlogCards(Title,[Text],[Image],[Date])
VALUES ('Flower Power','Class aptent taciti sociosqu ad litora torquent per conubia nostra, per','blog-feature-img-1.jpg','2019-12-25'),
('Local Florists','Class aptent taciti sociosqu ad litora torquent per conubia nostra, per','blog-feature-img-3.jpg','2020-01-23'),
('Flower Beauty','Class aptent taciti sociosqu ad litora torquent per conubia nostra, per','blog-feature-img-4.jpg','2021-10-14')

INSERT INTO dbo.BlogHeading(Title,[Text])
VALUES ('From our Blog','A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.')

INSERT INTO dbo.Categories(Title)
VALUES ('Popular'),('Winter'),('Cactuses'),('Greens'),('Exotic'),('Various')

INSERT INTO dbo.ExpertHeading(Title,[Text])
VALUES ('Flower Experts','A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.')

INSERT INTO dbo.Professions([Name])
VALUES ('Florist'),('Manager')

INSERT INTO dbo.Experts(Fullname,ProfessionId,[Image])
VALUES ('Crystal Brooks',1,'h3-team-img-1.png'),
('Shirley Harris',2,'h3-team-img-2.png'),
('Beverly Clark',1,'h3-team-img-3.png'),
('Amanda Watkins',1,'h3-team-img-4.png')


INSERT INTO dbo.ExpertSliders(Fullname,[Text],[Image],ProfessionId)
VALUES ('Jasmine White','Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus
 lingua.','testimonial-img-2.png',1),
('Anna Barnes','Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget.','testimonial-img-1.png',2)

INSERT INTO dbo.InstagramPhotos(Photo)
VALUES ('instagram1.jpg'),('instagram2.jpg'),('instagram3.jpg'),('instagram4.jpg'),
('instagram5.jpg'),('instagram6.jpg'),('instagram7.jpg'),('instagram8.jpg')

INSERT INTO dbo.Products([Title],[Price],[Count],[Image])
VALUES ('Item-1',36.99,25,'shop-10-img.jpg'),
('Item-2',25.50,100,'shop-9-img.jpg'),
('Item-3',13.00,85,'shop-8-img.jpg'),
('Item-4',10.30,78,'shop-7-img.jpg'),
('Item-5',14.90,45,'shop-11-img.jpg'),
('Item-6',41.36,56,'shop-12-img.jpg'),
('Item-7',75.40,62,'shop-13-img.jpg'),
('Item-8',90.00,35,'shop-14-img.jpg'),
('Item-9',36.99,25,'shop-10-img.jpg'),
('Item-10',25.50,100,'shop-9-img.jpg'),
('Item-11',13.00,85,'shop-8-img.jpg'),
('Item-12',10.30,78,'shop-7-img.jpg'),
('Item-13',14.90,45,'shop-11-img.jpg'),
('Item-14',41.36,56,'shop-12-img.jpg'),
('Item-15',75.40,62,'shop-13-img.jpg'),
('Item-16',190.00,35,'shop-14-img.jpg'),
('Item-17',10.30,78,'shop-7-img.jpg')

INSERT INTO dbo.ProductCategories(ProductId,CategoryId)
VALUES (1,1),(2,3),(3,2),(4,5),(5,4),(6,6),(7,4),(8,3),(9,1),(10,1),(11,2),(12,6),(13,5),(14,3),
(15,4),(16,2),(17,3)

INSERT INTO dbo.Sliders([ImagePath])
VALUES ('h3-slider-background.jpg'),('h3-slider-background-2.jpg'),('h3-slider-background-3.jpg')

INSERT INTO dbo.Slogan([Title],[Text],[Image])
VALUES ('<h1>Send <span>flowers</span> like</h1><h1>you mean it</h1>','Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will make it special cursus a sit amet mauris.','h2-sign-img.png')